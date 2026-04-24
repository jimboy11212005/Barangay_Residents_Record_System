using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BRRAPI.Models;
using BRRAPI.Services;

namespace BRRAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly BarangayService _service;

        public AuthController(BarangayService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User credentials)
        {
            if (credentials == null || string.IsNullOrWhiteSpace(credentials.Username) || string.IsNullOrWhiteSpace(credentials.Password))
                return BadRequest("Username and password are required.");

            var user = _service.GetUsers()
                .FirstOrDefault(u => u.Username == credentials.Username && u.Password == credentials.Password);

            if (user == null)
                return Unauthorized();

            return Ok(new { user.UserId, user.Username, user.Role });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
                return BadRequest("Username and password required.");

            if (_service.GetUsers().Any(u => u.Username == user.Username))
                return Conflict("Username already exists.");

            _service.AddUser(user);

            return CreatedAtAction(nameof(Register), new { id = user.UserId }, new { user.UserId, user.Username });
        }
    }
}
