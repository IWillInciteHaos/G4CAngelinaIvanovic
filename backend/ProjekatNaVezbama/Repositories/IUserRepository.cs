using ProjekatNaVezbama.Model;
using ProjekatNaVezbama.DTO;

namespace ProjekatNaVezbama.Repositories
{
    public interface IUserRepository
    {
        public UserOutDTO CreateUser(UserCreateDTO dtoIN);
        public bool DeleteUser(string userID);
        public bool UpdateUser(string userID, string password = "", string email = "", User addFollower = null, User followAnother = null, Post newPost = null, Post likedPost = null, Comment likedComment = null);
        public User GetUser(string userID);
        public List<User> GetAllUsers();
    }
}
