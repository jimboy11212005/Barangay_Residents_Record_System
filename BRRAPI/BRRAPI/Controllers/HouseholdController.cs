using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BRRAPI.Models;
using BRRAPI.Services;

namespace BRRAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HouseholdController : ControllerBase
    {
        private readonly BarangayService _service;
        public HouseholdController(BarangayService service) => _service = service ?? throw new ArgumentNullException(nameof(service));

        [HttpPost("add")]
        public IActionResult AddHousehold([FromBody] Household household)
        {
            if (household == null) return BadRequest("Household cannot be null.");
            _service.AddHousehold(household);
            return CreatedAtAction(nameof(GetHouseholdById), new { id = household.HouseholdId }, household);
        }

        [HttpGet("all")]
        public ActionResult<List<Household>> GetAllHouseholds() => Ok(_service.GetHouseholds());

        [HttpGet("{id}")]
        public ActionResult<Household> GetHouseholdById(int id)
        {
            var hh = _service.GetHouseholdById(id);
            if (hh == null) return NotFound();
            return Ok(hh);
        }

        [HttpGet("{id}/members")]
        public ActionResult<List<Resident>> GetHouseholdMembers(int id)
        {
            var hh = _service.GetHouseholdById(id);
            if (hh == null) return NotFound();
            return Ok(hh.Members ?? new List<Resident>());
        }

        [HttpGet("search")]
        public ActionResult<List<Household>> SearchHousehold([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return BadRequest("Keyword is required.");
            var result = _service.GetHouseholds()
                .Where(h => !string.IsNullOrWhiteSpace(h.HouseholdName) && h.HouseholdName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
            return Ok(result);
        }
    }
}
