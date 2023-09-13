namespace ProjekatNaVezbama.Model
{
    public class User
    {
        public int ID { get; set; }
        //should be unique
        public string Username { get; set; }
        public string Password { get; set; }
        //public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public List<User> Followers { get; set; }
        public List<Post> Posts { get; set; }
        public List<Post> LikedPosts { get; set; }

        public User() { }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            Followers = new List<User>();
            Posts = new List<Post>();
            LikedPosts = new List<Post>();

        }

    }
}
