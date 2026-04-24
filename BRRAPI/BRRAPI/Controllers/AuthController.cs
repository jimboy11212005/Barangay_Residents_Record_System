using System.Linq;
using BRRAPI.Core;
using BRRAPI.Models;
using BRRAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BRRAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly BarangayService service = ServiceLocator.Service;

        [HttpPost("login")]
        public bool Login(string username, string password)
        {
            return service.GetUsers()
                .Any(u => u.Username == username && u.Password == password);
        }
    }
}
