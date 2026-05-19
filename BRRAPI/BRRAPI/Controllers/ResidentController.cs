using BRRAPI.Data;
using BRRAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BRRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResidentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resident>>>
            GetResidents()
        {
            return await _context.Residents.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Resident>>
            AddResident(Resident resident)
        {
            _context.Residents.Add(resident);

            await _context.SaveChangesAsync();

            return Ok(resident);
        }
    }
}