using ProjekatNaVezbama.DTO;
using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.Repositories
{
    public interface IPostRepository
    {
        public Task<Post> CreatePost(Post post);
        public Task DeletePost(Post ID);
        public Task DeleteMultiplePosts(List<Post> posts);
        bool UpdatePost(string content, int ID);
        public Task<Post> GetPost(int id);
        public Task<IEnumerable<Post>> GetAllPosts();
        public Task<IEnumerable<Post>> GetUsersPosts(User u);
        public Task<bool> CheckIfUserExists(string username);
    }
}
