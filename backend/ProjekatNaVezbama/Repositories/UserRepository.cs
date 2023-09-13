using Microsoft.IdentityModel.Tokens;
using ProjekatNaVezbama.DB;
using ProjekatNaVezbama.DTO;
using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBPostItContext _repository;
        public UserRepository(DBPostItContext repository)
        {
            _repository = repository;
        }

        public UserOutDTO CreateUser(UserCreateDTO dtoIN)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(string userID)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            // get all users or say nah
            List<User> retVal = new List<User>();
            if (_repository.Users.Any())
            {
                retVal = _repository.Users.ToList();
            }

            return retVal;
        }

        public User GetUser(string userID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(string userID, string password = "", string email = "", User addFollower = null, User followAnother = null, Post newPost = null, Post likedPost = null, Comment likedComment = null)
        {
            throw new NotImplementedException();
        }
    }
}
