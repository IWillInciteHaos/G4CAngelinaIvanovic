using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.DTO
{
    public class PostOutDTO
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public string CreatorUsername { get; set; }
        public List<Comment> Comments { get; set; }
        public List<User> LikedBy { get; set; }
    }
}
