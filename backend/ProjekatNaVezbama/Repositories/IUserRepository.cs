using ProjekatNaVezbama.Model;
using ProjekatNaVezbama.DTO;

namespace ProjekatNaVezbama.Repositories
{
    public interface IUserRepository
    {
        public Task<User> CreateUser(User user);
        public Task DeleteUser(User user);
        //public bool UpdateUser(string userID, string password = "", string email = "", User addFollower = null, User followAnother = null, Post newPost = null, Post likedPost = null, Comment likedComment = null);
        public Task<User> GetUser(int uID);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> UpdateUser(User newUser);
        public Task<bool> UsernameExists(string username);       
        public Task<User> GetUserByUsername(string username);
    }
}
