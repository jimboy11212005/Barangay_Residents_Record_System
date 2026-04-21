using System.Collections.Generic;
using System.Linq;
using BRRAPI.Core;
using BRRAPI.Models;

namespace BRRAPI.Controllers
{
    public class HouseholdController
    {
        private BarangayService service = ServiceLocator.Service;

        public void AddHousehold(Household household)
        {
            service.AddHousehold(household);
        }

        public List<Household> GetAllHouseholds()
        {
            return service.GetHouseholds();
        }

        public List<Resident> GetHouseholdMembers(int householdId)
        {
            var household = service.GetHouseholds()
                .FirstOrDefault(h => h.HouseholdId == householdId); // ✅ FIXED

            return household?.Members ?? new List<Resident>();
        }

        public List<Household> SearchHousehold(string keyword)
        {
            return service.GetHouseholds()
                .Where(h => h.HouseholdName.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }
    }
}
