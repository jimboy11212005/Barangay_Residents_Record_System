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
    public class ResidentController : ControllerBase
    {
        private readonly BarangayService _barangayService;

        // Use DI for the service. Program.cs should register BarangayService.
        public ResidentController(BarangayService barangayService)
        {
            _barangayService = barangayService ?? throw new ArgumentNullException(nameof(barangayService));
        }

        [HttpPost("add")]
        public IActionResult AddResident([FromBody] Resident resident)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (resident == null)
                return BadRequest("Resident cannot be null.");

            try
            {
                _barangayService.AddResident(resident);
                return CreatedAtAction(nameof(GetResidentById), new { id = resident.ResidentId }, resident);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the resident: {ex.Message}");
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateResident(int id, [FromBody] Resident resident)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (resident == null)
                return BadRequest("Resident cannot be null.");

            if (id != resident.ResidentId)
                return BadRequest("Resident ID mismatch.");

            try
            {
                _barangayService.UpdateResident(resident);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the resident: {ex.Message}");
            }
        }

        [HttpDelete("delete/{residentId}")]
        public IActionResult DeleteResident(int residentId)
        {
            try
            {
                _barangayService.DeleteResident(residentId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the resident: {ex.Message}");
            }
        }

        [HttpGet("all")]
        public ActionResult<List<Resident>> GetAllResidents()
        {
            try
            {
                var residents = _barangayService.GetResidents();
                return Ok(residents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving residents: {ex.Message}");
            }
        }

        [HttpGet("search")]
        public ActionResult<List<Resident>> SearchResident([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            try
            {
                var residents = _barangayService.SearchResident(keyword);
                return Ok(residents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while searching residents: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public ActionResult<List<Resident>> FilterByCategory([FromQuery] string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return BadRequest("Category is required.");

            try
            {
                var residents = _barangayService.GetByCategory(category);
                return Ok(residents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while filtering residents: {ex.Message}");
            }
        }

        [HttpGet("pwd")]
        public ActionResult<List<Resident>> GetPWDResidents()
        {
            try
            {
                var residents = _barangayService.GetPWDResidents();
                return Ok(residents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving PWD residents: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Resident> GetResidentById(int id)
        {
            try
            {
                var resident = _barangayService.GetResidentById(id);
                if (resident == null)
                    return NotFound($"Resident with ID {id} not found.");

                return Ok(resident);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving resident: {ex.Message}");
            }
        }
    }
}