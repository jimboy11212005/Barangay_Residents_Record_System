using BRRAPI.Core;
using BRRAPI.Models;

namespace BRRAPI.Controllers
{
    public class DashboardController
    {
        private BarangayService service = ServiceLocator.Service;

        public int GetTotalResidents()
        {
            return service.GetResidents().Count;
        }

        public int GetChildrenCount()
        {
            return service.GetResidents()
                .Count(r => r.GetCategory() == "Child");
        }

        public int GetAdultCount()
        {
            return service.GetResidents()
                .Count(r => r.GetCategory() == "Adult");
        }

        public int GetSeniorCount()
        {
            return service.GetResidents()
                .Count(r => r.GetCategory() == "Senior");
        }

        public int GetPWDCount()
        {
            return service.GetResidents()
                .Count(r => r.IsPWD);
        }
    }
}
