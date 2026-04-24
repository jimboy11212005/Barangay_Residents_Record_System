using System;
using System.Collections.Generic;
using System.Linq;
using BRRAPI.Core;
using BRRAPI.Models;
using BRRAPI.Services;

namespace BRRAPI.Controllers
{
    public class HouseholdController
    {
        private readonly BarangayService service = ServiceLocator.Service;

        public HouseholdController() { }

        public void AddHousehold(Household household)
        {
            if (household == null) throw new ArgumentNullException(nameof(household));
            service.AddHousehold(household);
        }

        public List<Household> GetAllHouseholds()
        {
            return service.GetHouseholds();
        }

        public Household GetHouseholdById(int householdId)
        {
            return service.GetHouseholdById(householdId);
        }

        public List<Resident> GetHouseholdMembers(int householdId)
        {
            var household = GetHouseholdById(householdId);
            return household?.Members?.ToList() ?? new List<Resident>();
        }

        public List<Household> SearchHousehold(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return new List<Household>();

            var term = keyword.Trim();
            return service.GetHouseholds()
                .Where(h => !string.IsNullOrWhiteSpace(h.HouseholdName) &&
                            h.HouseholdName.Contains(term, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
