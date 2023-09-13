using ProjekatNaVezbama.DB;
using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DBPostItContext _repository;
        public CommentRepository(DBPostItContext repository)
        {
            _repository = repository;
        }
        public bool CreateComment(string message, int creatorID, int postID)
        {
            bool retVal = false;
            //Check if the creator and post exist
            if (
                !_repository.Users.Where(user => user.Username.Equals(creatorID)).Any()
                && !_repository.Posts.Where(p=> p.ID.Equals(postID)).Any()
                )
            {
                _repository.Comments.Add(new Comment(message, creatorID, postID));
                retVal = true;

            }

            return retVal;
        }

        public bool DeleteComment(Comment c)
        {
            bool retVal = false;
            
            if ( _repository.Posts.Where(p => p.ID.Equals(c.ID)).Any() )
            {
                _repository.Comments.Remove(c);
                retVal = true;

            }

            return retVal;
        }

        public List<Post> GetAllComments()
        {
            List<Post> retVal = new List<Post>();

            retVal = _repository.Posts.Select(p => p).ToList(); 

            return retVal;
        }

        public Post GetComment(int id)
        {
            Post retVal = new Post();

            retVal = _repository.Posts.Where(p => p.ID == id).FirstOrDefault();

            return retVal;

        }

        public bool UpdateComment(string content, int ID)
        {
            bool retVal = false;
            //Check if the creator and post exist
            if ( _repository.Comments.Where(c => c.ID == ID).Any() )
            {
                //how to actually update one element in database from here?

            }

            return retVal;
        }
    }
}
