using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BRRAPI.Services;

namespace BRRAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly BarangayService _service;
        public DashboardController(BarangayService service) => _service = service;

        [HttpGet("total-residents")] public ActionResult<int> GetTotalResidents() => Ok(_service.GetResidents().Count);
        [HttpGet("children-count")] public ActionResult<int> GetChildrenCount() => Ok(_service.GetResidents().Count(r => r.GetCategory() == "Child"));
        [HttpGet("adult-count")] public ActionResult<int> GetAdultCount() => Ok(_service.GetResidents().Count(r => r.GetCategory() == "Adult"));
        [HttpGet("senior-count")] public ActionResult<int> GetSeniorCount() => Ok(_service.GetResidents().Count(r => r.GetCategory() == "Senior"));
        [HttpGet("pwd-count")] public ActionResult<int> GetPWDCount() => Ok(_service.GetResidents().Count(r => r.IsPWD));
    }
}
