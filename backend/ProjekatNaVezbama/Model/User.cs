namespace ProjekatNaVezbama.Model
{
    public class User
    {
        public int ID { get; set; }
        public bool isActive { get; set; }
        //should be unique
        public string Username { get; set; }
        public string Password { get; set; }
        //public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        //public List<Follower> Followers { get; set; } = new List<Follower>();
        //public List<Follower> Following { get; set; } = new List<Follower>();
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Post> LikedPosts { get; set; } = new List<Post>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Comment> LikedComments { get; set; } = new List<Comment>();

        public User() { }


    }
}
