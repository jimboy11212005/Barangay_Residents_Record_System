using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BRRAPI.Models;
using BRRAPI.Services;

namespace BRRAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly BarangayService _service;
        public ReportController(BarangayService service) => _service = service;

        [HttpGet("residents")]
        public ActionResult<List<Resident>> GenerateResidentReport() => Ok(_service.GetResidents());

        [HttpGet("households")]
        public ActionResult<List<Household>> GenerateHouseholdReport() => Ok(_service.GetHouseholds());
    }
}
