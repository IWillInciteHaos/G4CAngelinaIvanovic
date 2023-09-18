using ProjekatNaVezbama.Model;
using System.ComponentModel.DataAnnotations;

namespace ProjekatNaVezbama.DTO
{
    public class CommentCreateDTO
    {
        [Required]
        public string Message { get; set; }
        //user who made the message
        [Required]
        public string CreatorUsername { get; set; }
        [Required]
        public int PostID { get; set; }
    }
}
