using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.Repositories
{
    public interface ICommentRepository
    {

        bool CreateComment(string message, string creatorID, int postID);
        bool DeleteComment(Comment c);
        bool UpdateComment(string content, int ID);
        Post GetComment(int id);
        List<Post> GetAllComments();
    }
}
