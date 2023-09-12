using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.Repositories
{
    public interface IPostRepository
    {
        bool CreatePost(User user, string content);
        bool DeletePost(Post ID);
        bool UpdatePost(string content, int ID);
        Post GetPost(int id);
        List<Post> GetAllPosts();
    }
}
