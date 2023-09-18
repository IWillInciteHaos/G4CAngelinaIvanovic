using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjekatNaVezbama.DB;
using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DBPostItContext _repository;
        public PostRepository(DBPostItContext repository)
        {
            _repository = repository;
        }

        public async Task<bool> CheckIfUserExists(string username)
        {
            return _repository.Users.Where(u => u.Username.CompareTo(username) == 0).Any();
        }
        public async Task<Post> CreatePost(Post post)
        {
            //Post retVal = null;
            //Check if the username exists
            //var temp = _repository.Users.Where(u => u.Username.CompareTo(post.Creator.Username) == 0).FirstOrDefault();
            //if (_repository.Users.Where(u => u.Username.CompareTo(post.Creator.Username) == 0).Any())
            //{
            var tempUser = _repository.Users.Where(u => u.Username.CompareTo(post.Creator.Username) == 0).FirstOrDefault();
            post.Creator = tempUser;
            post.CreatorID = tempUser.ID;

            await _repository.Posts.AddAsync(post);
            await _repository.SaveChangesAsync();
                
            //}

            return post;
        }

        public async Task DeletePost(Post post)
        {
            _repository.Posts.Remove(post);
            await _repository.SaveChangesAsync();
        }

        //get all in what context?
        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            IEnumerable<Post> retVal = null;
            //                                      add creator
            retVal = await _repository.Posts.Include(e=> e.Creator).Select(p => p).ToListAsync();

            return retVal;
        }

        //should I add getAllUserAllowed?
        public async Task<Post> GetPost(int pID)
        {
            return await _repository.Posts.AsNoTracking().FirstOrDefaultAsync(post => post.ID == pID);
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
