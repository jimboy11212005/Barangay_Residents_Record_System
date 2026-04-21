using BRRAPI.Core;
using BRRAPI.Models;

namespace BRRAPI.Controllers
{
    public class ReportController
    {
        private BarangayService service = ServiceLocator.Service;

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
