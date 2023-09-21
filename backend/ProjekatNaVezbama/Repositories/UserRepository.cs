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
        private readonly IPostRepository _postRepository;
        public UserRepository(DBPostItContext repository, IPostRepository postRepository)
        {
            _repository = repository;
            _postRepository = postRepository;
        }
        /*
        public List<Follower> GetUserFollowers(User user)
        {
            _repository.Follower
        }*/
        public async Task<User> GetUserByUsername(string username)
        {
            return await _repository.Users.Where(u => u.Username.CompareTo(username) == 0).FirstOrDefaultAsync();
        }

        //user exists check??
        public async Task<bool> UsernameExists(string username)
        {
            return await _repository.Users.Where(user => user.Username.CompareTo(username) == 0).AnyAsync();

        }

        public async Task<User> CreateUser(User user)
        {
            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUser(User u)
        {
            u.isActive = false;
            _repository.Update(u);

            await _repository.SaveChangesAsync();

            var tempPosts = _repository.Posts.Where(p => p.CreatorID == u.ID).ToList();
            _postRepository.DeleteMultiplePosts(tempPosts);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            // get all users or say nah
            return await _repository.Users.AsNoTracking().Where(u => u.isActive).ToListAsync();
        }

        public async Task<User> GetUser(int uID)
        {
            return await _repository.Users.AsNoTracking()
                .Where(user => user.ID == uID).FirstOrDefaultAsync(user => user.isActive);
        }


        public async Task<User> UpdateUser(User newUser)
        {
            _repository.Update(newUser);
            await _repository.SaveChangesAsync();

            return newUser;
        }
    }
}
