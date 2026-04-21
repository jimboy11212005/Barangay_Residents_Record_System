namespace BRRAPI.Models
{
    public class Household
    {
        public int HouseholdId { get; set; }

        public string HouseholdName { get; set; }
        public string Address { get; set; } // Purok / Street

        public string HeadOfHousehold { get; set; }

        // 👨‍👩‍👧 Members of the family
        public List<Resident> Members { get; set; } = new List<Resident>();
    }
}
