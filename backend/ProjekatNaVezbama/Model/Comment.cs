namespace ProjekatNaVezbama.Model
{
    public class Comment
    {
        public int ID { get; set; }
        public bool isActive { get; set; }
        public string Message { get; set; }
        //user who made the message
        public int CreatorID { get; set; }
        public User Creator { get; set; }
        public int LikeCount { get; set; }
        public int OriginPostID { get; set; }
        public Post OriginPost { get; set; }
    }
}
