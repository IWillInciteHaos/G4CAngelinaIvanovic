using Microsoft.Build.Framework;
using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.DTO
{
    public class UserUpdateCreateDTO
    {
        public int ID { get; set; }
        [Required]
        public string Username { get; set; }
        public string NewUsername { get; set; }
        [Required]
        public string Password { get; set; }
        public string NewPassword { get; set; }
        [Required]
        public string Email { get; set; }
        public string NewEmail { get; set; }
    }
}
