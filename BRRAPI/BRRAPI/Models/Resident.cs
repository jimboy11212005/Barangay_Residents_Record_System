namespace BRRAPI.Models
{
    public class Resident
    {
        public int ResidentId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public bool IsPWD { get; set; }

        // 🏡 Optional health info
        public string MedicalCondition { get; set; }
        public string Medication { get; set; }

        public int HouseholdId { get; set; }

        // =========================
        // 📌 METHODS (YOUR LOGIC)
        // =========================

        // 👶 AGE COMPUTATION
        public int GetAge()
        {
            int age = DateTime.Now.Year - BirthDate.Year;

            if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
                age--;

            return age;
        }

        // 📊 CATEGORY (Child, Adult, Senior)
        public string GetCategory()
        {
            int age = GetAge();

            if (age <= 12)
                return "Child";
            else if (age <= 59)
                return "Adult";
            else
                return "Senior";
        }

        // ♿ PWD CHECK
        public bool IsPWDResident()
        {
            return IsPWD;
        }
    }
}
