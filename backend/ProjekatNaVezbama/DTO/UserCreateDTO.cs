using ProjekatNaVezbama.Model;
using System.ComponentModel.DataAnnotations;

namespace ProjekatNaVezbama.DTO
{
    public class UserCreateDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        //public DateTime CreatedDate { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
