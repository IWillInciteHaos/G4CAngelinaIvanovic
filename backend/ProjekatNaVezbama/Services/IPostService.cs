using ProjekatNaVezbama.DTO;

namespace ProjekatNaVezbama.Services
{
    public interface IPostService
    {
        //Add to select only user's posts or all public posts?
        public Task<PostOutDTO> CreatePost(PostCreateDTO postDTO);
        public Task<IEnumerable<PostOutDTO>> GetAllPosts();
        public Task<PostOutDTO> GetPost(int postID);
        public Task<bool> DeletePost(int id);
    }
}
