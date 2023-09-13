using ProjekatNaVezbama.Model;
using ProjekatNaVezbama.Repositories;

namespace ProjekatNaVezbama.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
