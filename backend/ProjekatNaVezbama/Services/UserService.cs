using AutoMapper;
using NuGet.Protocol.Core.Types;
using ProjekatNaVezbama.DTO;
using ProjekatNaVezbama.Model;
using ProjekatNaVezbama.Repositories;

namespace ProjekatNaVezbama.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserOutDTO> CreateUser(UserCreateDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var retVal = await _userRepository.CreateUser(user);

            return _mapper.Map<UserOutDTO>(retVal);
        }

        public async Task<bool> DeleteUser(int id)
        {
            var exists = await _userRepository.GetUser(id);
            if (exists == null)
            {
                return false;
            }

            await _userRepository.DeleteUser(exists);

            return true;
        }


        //get all users from database
        public async Task<IEnumerable<UserOutDTO>> GetAllUsers()
        {
            var retVal = await _userRepository.GetAllUsers();
            return _mapper.Map<IEnumerable<UserOutDTO>>(retVal);
        }

        public async Task<UserOutDTO> GetUser(int userID)
        {
            var tempUser = await _userRepository.GetUser(userID);

            if(tempUser != null)
            {
                return null;
            }

            return _mapper.Map<UserOutDTO>(tempUser);
        }
    }
}
