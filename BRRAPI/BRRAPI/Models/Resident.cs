namespace BRRAPI.Models
{
    public class Resident
    {
        public int ResidentId { get; set; }

        public string QrCode { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string CivilStatus { get; set; }

        public string Citizenship { get; set; }

        public string Religion { get; set; }

        public string Occupation { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Purok { get; set; }

        public string HouseNo { get; set; }

        public string Street { get; set; }

        public string VoterStatus { get; set; }

        public string SeniorStatus { get; set; }

        public string PwdStatus { get; set; }

        public string ProfilePicture { get; set; }

        public DateTime DateRegistered { get; set; }
    }
}
