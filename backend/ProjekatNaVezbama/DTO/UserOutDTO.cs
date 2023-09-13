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
        public List<Comment> Commented { get; set; }

        public UserOutDTO() { }

        public UserOutDTO(
            string username,
            string email,
            List<User> followers,
            List<User> following,
            List<Post> posted,
            List<Post> likedPosts)
        {
            Username = username;
            Email = email;
            Followers = new List<User>(followers);
            Posts = new List<Post>(posted);
            LikedPosts = new List<Post>(likedPosts);

        }

        public UserOutDTO(User u)
        {
            Username = u.Username;
            Email = u.Email;
            Followers = u.Followers;
            Posts = u.Posts;
            LikedPosts = u.LikedPosts;
        }
    }
}
