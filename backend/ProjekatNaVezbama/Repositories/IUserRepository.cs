using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.Repositories
{
    public interface IUserRepository
    {
        bool CreateUser(string userID, string password, string email);
        bool DeleteUser(string userID);
        bool UpdateUser(string userID, string password = "", string email = "", User addFollower = null, User followAnother = null, Post newPost = null, Post likedPost = null, Comment likedComment = null);
        User GetUser(string userID);
        List<User> GetAllUsers();
    }
}
