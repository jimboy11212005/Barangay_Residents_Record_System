using System.ComponentModel.DataAnnotations.Schema;

namespace BRRAPI.DTOs
{
    public class RegisterDTO
    {
        [Column("full_name")]
        public string FullName { get; set; }

        [Column("username")]
        public string Username { get; set; }
        
        [Column("email")]
        public string Email { get; set; }

        [Column("password_hash")]
        public string Password { get; set; }
    }
}
