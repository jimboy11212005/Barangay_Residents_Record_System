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

        // ========================= RESIDENT OPERATIONS =========================
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
            if (resident == null) throw new InvalidOperationException("Resident not found");

            resident.FullName = updated.FullName;
            resident.BirthDate = updated.BirthDate;
            resident.Gender = updated.Gender;
            resident.Address = updated.Address;
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
            return _db.Residents
                .AsNoTracking()
                .FirstOrDefault(r => r.ResidentId == id);
        }

        public List<Resident> GetResidents()
        {
            return _db.Residents
                .AsNoTracking()
                .OrderByDescending(r => r.ResidentId)
                .ToList();
        }

        public List<Resident> SearchResident(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<Resident>();

            var pattern = $"%{keyword.Trim()}%";

            return _db.Residents
                .AsNoTracking()
                .Where(r =>
                    (r.FullName != null && EF.Functions.Like(r.FullName, pattern)) ||
                    (r.Address != null && EF.Functions.Like(r.Address, pattern)))
                .ToList();
        }

        public List<Resident> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return new List<Resident>();

            // GetCategory is instance logic — materialize and filter in memory
            return _db.Residents
                .AsNoTracking()
                .AsEnumerable()
                .Where(r => string.Equals(r.GetCategory(), category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Resident> GetPWDResidents()
        {
            return _db.Residents
                .AsNoTracking()
                .Where(r => r.IsPWD)
                .ToList();
        }

        // ========================= HOUSEHOLD OPERATIONS =========================
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

        // ========================= DASHBOARD STATS =========================
        public int GetTotalResidents() => _db.Residents.Count();
        public int GetChildrenCount() => GetResidents().Count(r => r.GetCategory() == "Child");
        public int GetAdultCount() => GetResidents().Count(r => r.GetCategory() == "Adult");
        public int GetSeniorCount() => GetResidents().Count(r => r.GetCategory() == "Senior");
        public int GetPWDCount() => _db.Residents.Count(r => r.IsPWD);
    }
}