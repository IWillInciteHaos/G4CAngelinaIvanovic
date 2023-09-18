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
        //change to active posts?
        public async Task<bool> CheckIfPostExists(int postID)
        {
            var retVal = false;
            var tempPost = await _repository.Posts.Where(p => p.ID == postID).FirstOrDefaultAsync();

            if (tempPost != null && tempPost.isActive)
            {

                retVal = true;
            }

            return retVal;
        }

        public async Task<bool> CheckIfUserExists(string username)
        {
            var retVal = false;
            var tempUser = await _repository.Users.Where(u => u.Username.CompareTo(username) == 0).FirstOrDefaultAsync();

            if (tempUser != null && tempUser.isActive)
            {

                retVal = true;
            }

            return retVal;
            
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            var tempUser = _repository.Users.Where(u => u.Username.CompareTo(comment.Creator.Username) == 0).FirstOrDefault();
            comment.Creator = tempUser;
            comment.CreatorID = tempUser.ID;
            
            var tempPost = _repository.Posts.Where(p => p.ID == comment.OriginPostID).FirstOrDefault();
            comment.OriginPost = tempPost;
            comment.OriginPostID = tempPost.ID;

            comment.isActive = true;

            await _repository.Comments.AddAsync(comment);
            await _repository.SaveChangesAsync();

            return comment;

        }

        public async Task DeleteComment(Comment comment)
        {
            comment.isActive = false;
            _repository.Update(comment);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteMultipleComments(List<Comment> comments)
        {
            foreach (var comment in comments)
            {
                comment.isActive = false;
                _repository.Update(comment);
            }

            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllComments() 
        {
            //                                             add creator
            IEnumerable<Comment> retVal = null;
            retVal = await _repository.Comments.Include(c => c.Creator).Include(c => c.OriginPost).Where(c=> c.isActive).ToListAsync();
            
            return retVal;
        }

        public async Task<Comment> GetComment(int commentID)
        {
            return await _repository.Comments.AsNoTracking().Where(c=>c.isActive).FirstOrDefaultAsync(comment => comment.ID == commentID);
        }
    }
}
