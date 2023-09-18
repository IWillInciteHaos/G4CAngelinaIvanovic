using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjekatNaVezbama.DB;
using ProjekatNaVezbama.Model;
using System.Security.Cryptography;

namespace ProjekatNaVezbama.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DBPostItContext _repository;
        public CommentRepository(DBPostItContext repository)
        {
            _repository = repository;
        }

        public async Task<bool> CheckIfPostExists(int postID)
        {
            return await _repository.Posts.Where(p => p.ID == postID).AnyAsync();
        }

        public async Task<bool> CheckIfUserExists(string username)
        {
            return await _repository.Users.Where(u => u.Username.CompareTo(username) == 0).AnyAsync();
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            var tempUser = _repository.Users.Where(u => u.Username.CompareTo(comment.Creator.Username) == 0).FirstOrDefault();
            comment.Creator = tempUser;
            comment.CreatorID = tempUser.ID;
            
            var tempPost = _repository.Posts.Where(p => p.ID == comment.OriginPostID).FirstOrDefault();
            comment.OriginPost = tempPost;
            comment.OriginPostID = tempPost.ID;

            await _repository.Comments.AddAsync(comment);
            await _repository.SaveChangesAsync();

            return comment;

        }

        public async Task DeleteComment(Comment comment)
        {
            _repository.Comments.Remove(comment);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllComments() 
        { 
            IEnumerable<Comment> retVal = null;
            //                                      add creator
            retVal = await _repository.Comments.Include(c => c.Creator).Include(c => c.OriginPost).Select(p => p).ToListAsync();

            return retVal;
        }

        public async Task<Comment> GetComment(int commentID)
        {
            return await _repository.Comments.AsNoTracking().FirstOrDefaultAsync(comment => comment.ID == commentID);
        }
    }
}
