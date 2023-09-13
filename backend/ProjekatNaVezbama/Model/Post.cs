namespace ProjekatNaVezbama.Model
{
    public class Post
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public int CreatorID { get; set; }
        public User Creator { get; set; }
        public List<Comment> Comments { get; set; }
        public List<User> LikedBy { get; set; }

        public Post() { }
        public Post(User user, string content)
        {
            Content = content;
            Creator = user;
            DateCreated = DateTime.Now;
            LikeCount = 0;
            Comments = new List<Comment>();
        }


    }
}
