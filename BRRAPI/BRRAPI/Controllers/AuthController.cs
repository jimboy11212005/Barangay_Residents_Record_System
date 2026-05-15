using BRRAPI.Data;
using BRRAPI.DTOs;
using BRRAPI.Models;
using BRRAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BRRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (await _context.Users.AnyAsync(x => x.Username == dto.Username))
            {
                return BadRequest("Username already exists");
            }

            User user = new User()
            {
                FullName = dto.FullName,
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                RoleName = "Admin"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Registered Successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Username == dto.Username);

            if (user == null)
            {
                return Unauthorized("Invalid Username");
            }

            bool verify = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!verify)
            {
                return Unauthorized("Invalid Password");
            }

            var token = _jwtService.GenerateToken(user.Username, user.RoleName);

            return Ok(new
            {
                token = token,
                username = user.Username,
                role = user.RoleName
            });
        }
    }
}