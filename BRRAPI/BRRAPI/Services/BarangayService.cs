namespace BRRAPI.Models
{
    public class BarangayService
    {
        // 🧠 In-memory storage (temporary DB)
        private List<Resident> residents = new List<Resident>();
        private List<Household> households = new List<Household>();

        // =========================
        // 👤 RESIDENT OPERATIONS
        // =========================

        public void AddResident(Resident resident)
        {
            residents.Add(resident);
        }

        public void UpdateResident(Resident updated)
        {
            var resident = residents.FirstOrDefault(r => r.ResidentId == updated.ResidentId);

            if (resident != null)
            {
                resident.FullName = updated.FullName;
                resident.BirthDate = updated.BirthDate;
                resident.Address = updated.Address;
                resident.Gender = updated.Gender;
                resident.IsPWD = updated.IsPWD;
                resident.MedicalCondition = updated.MedicalCondition;
                resident.Medication = updated.Medication;
            }
        }

        public void DeleteResident(int id)
        {
            var resident = residents.FirstOrDefault(r => r.ResidentId == id);

            if (resident != null)
            {
                residents.Remove(resident);
            }
        }

        public List<Resident> GetResidents()
        {
            return residents;
        }

        // 🔍 SEARCH (SAFE VERSION)
        public List<Resident> SearchResident(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<Resident>();

            return residents
                .Where(r => r.FullName != null &&
                            r.FullName.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }

        // 📊 FILTER BY CATEGORY
        public List<Resident> GetByCategory(string category)
        {
            return residents
                .Where(r => r.GetCategory() == category)
                .ToList();
        }

        // ♿ PWD LIST
        public List<Resident> GetPWDResidents()
        {
            return residents
                .Where(r => r.IsPWD)
                .ToList();
        }

        // =========================
        // 🏠 HOUSEHOLD OPERATIONS
        // =========================

        public void AddHousehold(Household household)
        {
            households.Add(household);
        }

        public List<Household> GetHouseholds()
        {
            return households;
        }

        public Household GetHouseholdById(int id)
        {
            return households
                .FirstOrDefault(h => h.HouseholdId == id);
        }

        private List<User> users = new List<User>();

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
