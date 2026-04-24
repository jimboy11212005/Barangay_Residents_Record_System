using System;
using System.Collections.Generic;
using System.Linq;
using BRRAPI.Data;
using BRRAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BRRAPI.Services
{
    public class BarangayService
    {
        private readonly AppDbContext _db;

        public BarangayService(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        // =========================
        // 👤 RESIDENT OPERATIONS
        // =========================

        public void AddResident(Resident resident)
        {
            if (resident == null) throw new ArgumentNullException(nameof(resident));

            _db.Residents.Add(resident);
            _db.SaveChanges();
        }

        public void UpdateResident(Resident updated)
        {
            if (updated == null) throw new ArgumentNullException(nameof(updated));

            var resident = _db.Residents.Find(updated.ResidentId);
            if (resident == null) return;

            resident.FullName = updated.FullName;
            resident.BirthDate = updated.BirthDate;
            resident.Address = updated.Address;
            resident.Gender = updated.Gender;
            resident.IsPWD = updated.IsPWD;
            resident.MedicalCondition = updated.MedicalCondition;
            resident.Medication = updated.Medication;
            resident.HouseholdId = updated.HouseholdId;

            _db.SaveChanges();
        }

        public void DeleteResident(int id)
        {
            var resident = _db.Residents.Find(id);
            if (resident == null) return;

            _db.Residents.Remove(resident);
            _db.SaveChanges();
        }

        public Resident GetResidentById(int id)
        {
            return _db.Residents.AsNoTracking().FirstOrDefault(r => r.ResidentId == id);
        }

        public List<Resident> GetResidents()
        {
            return _db.Residents.AsNoTracking().ToList();
        }

        // 🔍 SEARCH
        public List<Resident> SearchResident(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<Resident>();

            var lowered = keyword.Trim().ToLowerInvariant();
            return _db.Residents
                .AsNoTracking()
                .Where(r => r.FullName != null && r.FullName.ToLower().Contains(lowered))
                .ToList();
        }

        // 📊 FILTER BY CATEGORY (in-memory because GetCategory uses logic)
        public List<Resident> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return new List<Resident>();

            return _db.Residents
                .AsNoTracking()
                .AsEnumerable()
                .Where(r => string.Equals(r.GetCategory(), category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // ♿ PWD LIST
        public List<Resident> GetPWDResidents()
        {
            return _db.Residents
                .AsNoTracking()
                .Where(r => r.IsPWD)
                .ToList();
        }

        // =========================
        // 🏠 HOUSEHOLD OPERATIONS
        // =========================

        public void AddHousehold(Household household)
        {
            if (household == null) throw new ArgumentNullException(nameof(household));

            _db.Households.Add(household);
            _db.SaveChanges();
        }

        public List<Household> GetHouseholds()
        {
            return _db.Households
                .Include(h => h.Members)
                .AsNoTracking()
                .ToList();
        }

        public Household GetHouseholdById(int id)
        {
            return _db.Households
                .Include(h => h.Members)
                .AsNoTracking()
                .FirstOrDefault(h => h.HouseholdId == id);
        }

        // =========================
        // 👥 USER OPERATIONS
        // =========================

        public void AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            // basic duplicate check
            if (_db.Users.Any(u => u.Username == user.Username))
                throw new InvalidOperationException("User with that username already exists.");

            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return _db.Users.AsNoTracking().ToList();
        }
    }
}