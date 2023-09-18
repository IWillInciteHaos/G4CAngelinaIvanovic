using Humanizer;
using Microsoft.EntityFrameworkCore;
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

        //user exists check??
        
        private bool UserExists(string username)
        {
            return _repository.Users.Where(user => user.Username.Equals(username)).Any();

        }
        
        public async Task<User> CreateUser(User user)
        {
            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUser(User u)
        {
            _repository.Users.Remove(u);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            // get all users or say nah
            return await _repository.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUser(int uID)
        {
            return await _repository.Users.AsNoTracking().FirstOrDefaultAsync(user => user.ID == uID);
        }

        /*
        public bool UpdateUser(string userID, string password = "", string email = "", User addFollower = null, User followAnother = null, Post newPost = null, Post likedPost = null, Comment likedComment = null)
        {
            throw new NotImplementedException();
        }
        */
    }
}
