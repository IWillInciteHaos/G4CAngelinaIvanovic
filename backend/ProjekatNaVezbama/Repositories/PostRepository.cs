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
        public bool CreatePost(User user, string content)
        {
            bool retVal = false;
            //Check if the username exists
            if (!_repository.Users.Where(user => user.Username.Equals(user.Username)).Any())
            {
                _repository.Posts.Add(new Post(user, content));
                 retVal = true;
                
            }

            return retVal;
        }

        public bool DeletePost(Post ID)
        {
            bool retVal = false;
            //Check if the post exists
            if (_repository.Posts.Where(p => p.ID == ID.ID).Any())
            {
                _repository.Posts.Remove(ID);
                retVal = true;

            }
            else
            {
                Console.WriteLine("#DeletePost# Post already deleted or you did something sus ");
            }

            return retVal;
        }

        //get all in what context?
        public List<Post> GetAllPosts()
        {
            List<Post> retVal = new List<Post>();

            //is there an error if there are no posts?
            retVal = _repository.Posts.Select(p => p).ToList();

            return retVal;
        }

        //should I add getAllUserAllowed?
        public Post GetPost(int id)
        {
            Post retVal = null;

            //is there an error if there are no posts?
            retVal = _repository.Posts.Where(p => p.ID == id).FirstOrDefault();

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
