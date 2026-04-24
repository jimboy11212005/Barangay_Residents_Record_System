using System.Linq;
using BRRAPI.Core;
using BRRAPI.Models;
using BRRAPI.Services;

namespace BRRAPI.Controllers
{
    public class DashboardController
    {
        private readonly BarangayService service = ServiceLocator.Service;

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
