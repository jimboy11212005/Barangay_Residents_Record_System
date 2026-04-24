using System.Collections.Generic;
using BRRAPI.Core;
using BRRAPI.Models;
using BRRAPI.Services;

namespace BRRAPI.Controllers
{
    public class ReportController
    {
        private readonly BarangayService service = ServiceLocator.Service;

        public List<Resident> GenerateResidentReport()
        {
            return service.GetResidents();
        }

        public List<Household> GenerateHouseholdReport()
        {
            return service.GetHouseholds();
        }
    }
}
