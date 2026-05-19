namespace BRRAPI.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("residents")]
    public class Resident
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Schema.Column("resident_id")]
        public int ResidentId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column("first_name")]
        public string FirstName { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column("last_name")]
        public string LastName { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column("gender")]
        public string Gender { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column("address")]
        public string Address { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column("age")]
        public int Age { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column("purok")]
        public string Purok { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column("pwd_status")]
        public string PwdStatus { get; set; }
    }
}