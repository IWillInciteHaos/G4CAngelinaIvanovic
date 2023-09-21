using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjekatNaVezbama.DB;
using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DBPostItContext _repository;
        private readonly ICommentRepository _commentRepository;
        public PostRepository(DBPostItContext repository, ICommentRepository commentRepository)
        {
            _repository = repository;
            _commentRepository = commentRepository;
        }

        /*
         
            bool retVal = false;
            var temp = await _repository.Users.Where(u => u.Username.CompareTo(username) == 0).FirstOrDefaultAsync();
            if(temp != null)
            {
                if(temp.isActive == true)
                {
                    retVal = true;
                }
            }

            return retVal;
         */

        public async Task<bool> CheckIfUserExists(string username)
        {
            var retVal = false;
            var tempUser = await _repository.Users.Where(u => u.Username.CompareTo(username) == 0).FirstOrDefaultAsync();

            if(tempUser != null && tempUser.isActive)
            {

                retVal = true;
            }

            return retVal;
        }

        public async Task<Post> CreatePost(Post post)
        {
            var tempUser = _repository.Users.Where(u => u.Username.CompareTo(post.Creator.Username) == 0).FirstOrDefault();
            post.Creator = tempUser;
            post.CreatorID = tempUser.ID;
            post.isActive = true;

            await _repository.Posts.AddAsync(post);
            await _repository.SaveChangesAsync();
                
            //}

            return post;
        }

        public async Task DeleteMultiplePosts(List<Post> posts)
        {
            foreach (var post in posts)
            {
                DeletePost(post);
            }
        }

        //don't actually delete it, just stop showing it
        public async Task DeletePost(Post post)
        {
            //var tempPost = _repository.Posts.Where(p => p.ID == post.ID).FirstOrDefault();
            post.isActive = false;
            //delete all the comments on the said post?
            _repository.Update(post);

            List<Comment> commentsChanged = _repository.Comments.Where(c => c.OriginPostID == post.ID).ToList();   
            _commentRepository.DeleteMultipleComments(commentsChanged);

            //await _repository.SaveChangesAsync();
            
        }

        //get all in what context?
        public async Task<IEnumerable<Post>> GetUsersPosts(User user)
        {
            //                                            add creator
            IEnumerable<Post> retVal = null;
            retVal = await _repository.Posts.Where(p => p.isActive && p.CreatorID == user.ID).ToListAsync();            

            return retVal;
        }
        
        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            //                                            add creator
            IEnumerable<Post> retVal = null;
            retVal = await _repository.Posts.Include(e=> e.Creator).Where(p => p.isActive).ToListAsync();            

            return retVal;
        }

        //should I add getAllUserAllowed?
        public async Task<Post> GetPost(int pID)
        {
            var retVal = await _repository.Posts.AsNoTracking().Where(p=> p.isActive).FirstOrDefaultAsync(post => post.ID == pID);
            
            return retVal;
        }

        public bool UpdatePost(string content, int ID)
        {
            bool retVal = false;
            //Check if the post exists
            if (_repository.Posts.Where(p => p.ID == ID).Any())
            {
                //Post tempPost = (Post) _repository.Posts.Where(p => p.ID == ID)
                //_repository.Posts.ElementAt(ID).Content = content;
                Console.WriteLine("User updated");
                retVal = true;

            }
            else
            {
                Console.WriteLine("#DeletePost# Post already deleted or you did something sus ");
            }

            return retVal;
        }
    }
}
