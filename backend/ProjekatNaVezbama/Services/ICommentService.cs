using Microsoft.AspNetCore.Mvc;
using ProjekatNaVezbama.DTO;

namespace ProjekatNaVezbama.Services
{
    public interface ICommentService
    {
        public Task<CommentOutDTO> CreateComment(CommentCreateDTO commentDTO);
        public Task<IEnumerable<CommentOutDTO>> GetAllComments();
        public Task<CommentOutDTO> GetComment(int commentID);
        public Task<List<CommentOutDTO>> GetPostComments(int postID);
        public Task<bool> DeleteComment(int commentID);
    }
}
