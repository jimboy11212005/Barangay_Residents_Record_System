using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BRRAPI.Data;
using BRRAPI.Services;
using BRRAPI.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Logging (helpful to see EF SQL and errors)
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

// Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
           .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
           .LogTo(Console.WriteLine, LogLevel.Information));

// Register application services
builder.Services.AddScoped<BarangayService>();

// Register controller as service so minimal endpoints can resolve it (optional)
builder.Services.AddTransient<AuthController>();

// Controllers + Swagger
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "BRRAPI", Version = "v1" }));

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Check DB connectivity and apply migrations safely
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var db = services.GetRequiredService<AppDbContext>();

        if (!db.Database.CanConnect())
        {
            logger.LogError("Cannot connect to DB. Check connection string and MySQL server.");
        }
        else
        {
            var pending = db.Database.GetPendingMigrations();
            logger.LogInformation("Pending migrations: {Count}", pending.Count());
            if (pending.Any())
            {
                try
                {
                    db.Database.Migrate();
                    logger.LogInformation("Migrations applied.");
                }
                catch (Exception ex) when (ex.Message?.Contains("already exists", StringComparison.OrdinalIgnoreCase) == true)
                {
                    logger.LogWarning(ex, "Migration conflict: existing objects detected. Manual reconciliation may be required.");
                    // continue so API runs; see reconciliation steps below
                }
            }
            else
            {
                logger.LogInformation("No pending migrations.");
            }
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Unexpected error while preparing database.");
        throw;
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

// Expose controllers normally
app.MapControllers();

// OPTIONAL: minimal API forwards so the IDE shows code references to the controller methods.
// These endpoints simply call the controller actions and create direct code references.
app.MapPost("/api/auth/register-ref", async (RegisterRequest request, [FromServices] AuthController auth) =>
{
    return await auth.Register(request);
});

app.MapPost("/api/auth/login-ref", async (LoginRequest request, [FromServices] AuthController auth) =>
{
    return await auth.Login(request);
});

app.Run();