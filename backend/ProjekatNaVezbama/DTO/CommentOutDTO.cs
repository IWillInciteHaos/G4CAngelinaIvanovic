using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.DTO
{
    public class CommentOutDTO
    {
        public int ID { get; set; }
        public string Message { get; set; }
        //user who made the message
        public string CreatorUsername { get; set; }
        public int LikeCount { get; set; }
        //do I need this?
        public int PostID { get; set; }
    }
}
