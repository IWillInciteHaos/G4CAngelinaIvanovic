using ProjekatNaVezbama.Model;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjekatNaVezbama.DTO
{
    public class PostCreateDTO
    {
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string CreatorUsername { get; set; }
    }
}
