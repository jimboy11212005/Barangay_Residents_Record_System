using System.ComponentModel.DataAnnotations.Schema;

namespace BRRAPI.Models
{
    public class User
    {
        [Column("user_id")]
        public int UserId { get; set; }


        [Column("full_name")]
        public string FullName { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password_hash")]
        public string Password { get; set; }

        [Column("role_name")]
        public string RoleName { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }
    }
}