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
        List<Comment> Comments { get; set; }
        List<User> LikedBy { get; set; }

        public Post() {}
        public Post(User user, string content)
        {
            Content = content;
            Creator = user;
            DateCreated = DateTime.Now;
            LikeCount = 0;
            Comments = new List<Comment>();
        }

        public void GetCommentedOn(Comment c) {
           // Comments.Add(c);
            Console.WriteLine("Comment made");
        }

        public void GetLiked(User u) {
            //one person can like one comment once
            //LikedBy.Add(u);
            LikeCount++;
            Console.WriteLine("Post Liked");
        }
    }
}
