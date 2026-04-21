using BRRAPI.Models;
using BRRAPI.Core;
using System.Collections.Generic;
using System.Linq;

namespace BRRAPI.Controllers
{
    public class ResidentController
    {
        // ✅ FIX: use correct ServiceLocator property
        private BarangayService service = ServiceLocator.Service;

        public void AddResident(Resident resident)
        {
            service.AddResident(resident);
        }

        public void UpdateResident(Resident resident)
        {
            service.UpdateResident(resident);
        }

        public void DeleteResident(int residentId)
        {
            service.DeleteResident(residentId);
        }

        public List<Resident> GetAllResidents()
        {
            return service.GetResidents();
        }

        public List<Resident> SearchResident(string keyword)
        {
            return service.GetResidents()
                .Where(r => r.FullName.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }

        public List<Resident> FilterByCategory(string category)
        {
            return service.GetResidents()
                .Where(r => r.GetCategory() == category)
                .ToList();
        }

        public List<Resident> GetPWDResidents()
        {
            return service.GetResidents()
                .Where(r => r.IsPWD)
                .ToList();
        }
    }
}