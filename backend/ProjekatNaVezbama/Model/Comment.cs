namespace ProjekatNaVezbama.Model
{
    public class Comment
    {
        public int ID { get; set; }
        public string Message { get; set; }
        //user who made the message
        public string CreatorID { get; set; }
        public User Creator { get; set; }
        public int LikeCount {  get; set; }
        public int OriginaPostID { get; set; }
        public Post OriginalPost { get; set; }
        public Comment() {}
        public Comment(string message, string creatorId, int postId)
        {
            Message = message;
            CreatorID = creatorId;
            OriginaPostID = postId; 
        }
    }
}
