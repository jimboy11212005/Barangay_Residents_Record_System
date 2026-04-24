using System;
using System.Collections.Generic;
using System.Linq;
using BRRAPI.Models;

namespace BRRAPI.Services
{
    public class BarangayService
    {
        // 🧠 In-memory storage (temporary DB)
        private readonly List<Resident> residents = new();
        private readonly List<Household> households = new();
        private readonly List<User> users = new();

        // =========================
        // 👤 RESIDENT OPERATIONS
        // =========================

        public void AddResident(Resident resident)
        {
            if (resident == null) throw new ArgumentNullException(nameof(resident));
            if (residents.Any(r => r.ResidentId == resident.ResidentId))
                throw new InvalidOperationException($"Resident with id {resident.ResidentId} already exists.");

            residents.Add(resident);

            // maintain household membership consistency
            if (resident.HouseholdId != 0)
            {
                var hh = GetHouseholdById(resident.HouseholdId);
                if (hh != null)
                {
                    hh.Members ??= new List<Resident>();
                    if (!hh.Members.Any(m => m.ResidentId == resident.ResidentId))
                        hh.Members.Add(resident);
                }
            }
        }

        public void UpdateResident(Resident updated)
        {
            if (updated == null) throw new ArgumentNullException(nameof(updated));

            var resident = residents.FirstOrDefault(r => r.ResidentId == updated.ResidentId);
            if (resident == null) return;

            // if household changed, move resident between households
            if (resident.HouseholdId != updated.HouseholdId)
            {
                var oldHousehold = GetHouseholdById(resident.HouseholdId);
                oldHousehold?.Members?.RemoveAll(m => m.ResidentId == resident.ResidentId);

                var newHousehold = GetHouseholdById(updated.HouseholdId);
                if (newHousehold != null)
                {
                    newHousehold.Members ??= new List<Resident>();
                    if (!newHousehold.Members.Any(m => m.ResidentId == updated.ResidentId))
                        newHousehold.Members.Add(updated);
                }
            }

            // update fields
            resident.FullName = updated.FullName;
            resident.BirthDate = updated.BirthDate;
            resident.Address = updated.Address;
            resident.Gender = updated.Gender;
            resident.IsPWD = updated.IsPWD;
            resident.MedicalCondition = updated.MedicalCondition;
            resident.Medication = updated.Medication;
            resident.HouseholdId = updated.HouseholdId;
        }

        public void DeleteResident(int id)
        {
            var resident = residents.FirstOrDefault(r => r.ResidentId == id);
            if (resident == null) return;

            var hh = GetHouseholdById(resident.HouseholdId);
            hh?.Members?.RemoveAll(m => m.ResidentId == id);

            residents.Remove(resident);
        }


        public List<Resident> GetResidents()
        {
            // return a snapshot to avoid external mutation of internal list
            return residents.ToList();
        }

        // 🔍 SEARCH (SAFE VERSION)
        public List<Resident> SearchResident(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<Resident>();

            return residents
                .Where(r => !string.IsNullOrWhiteSpace(r.FullName)
                            && r.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // 📊 FILTER BY CATEGORY
        public List<Resident> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return new List<Resident>();

            return residents
                .Where(r => string.Equals(r.GetCategory(), category, StringComparison.OrdinalIgnoreCase))
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
            if (household == null) throw new ArgumentNullException(nameof(household));
            if (households.Any(h => h.HouseholdId == household.HouseholdId))
                throw new InvalidOperationException($"Household with id {household.HouseholdId} already exists.");

            household.Members ??= new List<Resident>();
            households.Add(household);

            // attach existing residents that reference this household id
            foreach (var r in residents.Where(r => r.HouseholdId == household.HouseholdId))
            {
                if (!household.Members.Any(m => m.ResidentId == r.ResidentId))
                    household.Members.Add(r);
            }
        }

        public List<Household> GetHouseholds()
        {
            // ensure Members is never null and return a snapshot
            return households.Select(h =>
            {
                h.Members ??= new List<Resident>();
                return h;
            }).ToList();
        }

        public Household GetHouseholdById(int id)
        {
            return households.FirstOrDefault(h => h.HouseholdId == id);
        }

        // =========================
        // 👥 USER OPERATIONS
        // =========================

        public void AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (users.Any(u => u.UserId == user.UserId || string.Equals(u.Username, user.Username, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("User already exists.");

            users.Add(user);
        }

        public List<User> GetUsers()
        {
            return users.ToList();
        }
    }
}
