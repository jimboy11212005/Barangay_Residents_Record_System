using BRRAPI.Data;
using BRRAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;

namespace BRRAPI.Controllers
{
    [ApiController]
    [Route("api/auth")] // ✅ FIXED ROUTE
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AppDbContext context, ILogger<AuthController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // 🔐 HASH FUNCTION
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            if (string.IsNullOrWhiteSpace(login.Username) || string.IsNullOrWhiteSpace(login.Password))
                return BadRequest(new { message = "Username and password are required" });

            var hashedPassword = HashPassword(login.Password);

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username.ToLower() == login.Username.ToLower()
                                      && u.Password == hashedPassword);

            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok(new
            {
                token = Guid.NewGuid().ToString(),
                user = new
                {
                    username = user.Username,
                    role = user.Role
                }
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.FullName))
            {
                return BadRequest(new { message = "All fields are required" });
            }

            try
            {
                if (await _context.Users.AnyAsync(u => u.Username.ToLower() == request.Username.ToLower()))
                {
                    return BadRequest(new { message = "Username already exists" });
                }

                var user = new User
                {
                    FullName = request.FullName,
                    Username = request.Username,
                    Password = HashPassword(request.Password), // 🔐 HASHED
                    Role = "user"
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Registered successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registration error");
                return StatusCode(500, new { message = "Server error" });
            }
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class RegisterRequest
    {
        public string FullName { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }
}