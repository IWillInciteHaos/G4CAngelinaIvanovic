using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.DTO
{
    public class UserOutDTO
    {
        public string Username { get; set; }
        //public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public List<User> Followers { get; set; }
        public List<Post> Posts { get; set; }
        public List<Post> LikedPosts { get; set; }

    }
}
