using System.ComponentModel.DataAnnotations.Schema;

namespace BRRAPI.DTOs
{
    public class LoginDTO
    {
        public string Username { get; set; }

        [Column("password_hash")]
        public string Password { get; set; }
    }
}
