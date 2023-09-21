using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Core.Types;
using ProjekatNaVezbama.DTO;
using ProjekatNaVezbama.Model;
using ProjekatNaVezbama.Repositories;
using System.Collections.Generic;

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
            user.isActive = true;
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
            var tempUserList = await _userRepository.GetAllUsers();
            var retVal = tempUserList.ToList();
            foreach (var user in retVal)
            {
                if (!user.isActive)
                {
                    retVal.Remove(user);
                }
            }
            return _mapper.Map<IEnumerable<UserOutDTO>>(retVal);
        }

        public async Task<UserOutDTO> GetUser(int userID)
        {
            var tempUser = await _userRepository.GetUser(userID);

            if (tempUser == null || !tempUser.isActive)
            {
                return null;
            }

            return _mapper.Map<UserOutDTO>(tempUser);
        }
        public async Task<UserUpdateOutDTO> UpdateUser(UserUpdateCreateDTO userDTO)
        {
            var oldUser = await _userRepository.GetUser(userDTO.ID);

            if (oldUser == null || !oldUser.isActive)
            {
                return null;
            }

            //check if the user is valid
            var retVal = new UserUpdateOutDTO();
            if (!userDTO.Username.IsNullOrEmpty()  && oldUser.Username.ToLower().CompareTo(userDTO.Username) != 0)
            {
                retVal.Username = "-1";
            }
            else if (await _userRepository.UsernameExists(userDTO.NewUsername))
            {
                retVal.Username = "-2";
            }
            if (!userDTO.Email.IsNullOrEmpty() && oldUser.Email.ToLower().CompareTo(userDTO.Email) != 0)
            {
                retVal.Email = "-1";
            }
            if (!userDTO.Password.IsNullOrEmpty() && oldUser.Password.ToLower().CompareTo(userDTO.Password) != 0)
            {
                retVal.Username += "-1";
            }
            //maybe breaks here because Username is null?
            if (retVal.Username.Contains("-1") || retVal.Username.Contains("-2") 
                || retVal.Password.Contains("-1") 
                || retVal.Username.Contains("-1"))
            {                
                return _mapper.Map<UserUpdateOutDTO>(retVal);
            }

            //update user
            if (!userDTO.NewUsername.IsNullOrEmpty() && userDTO.NewUsername.ToLower().CompareTo(oldUser.Username.ToLower()) != 0)
            {
                oldUser.Username = userDTO.NewUsername;
            }
            if (!userDTO.NewEmail.IsNullOrEmpty() && userDTO.NewEmail.ToLower().CompareTo(oldUser.Email.ToLower()) != 0)
            {
                oldUser.Email = userDTO.NewEmail;
            }
            if (!userDTO.NewPassword.IsNullOrEmpty() && userDTO.NewPassword.ToLower().CompareTo(oldUser.Password.ToLower()) != 0)
            {
                oldUser.Password = userDTO.NewPassword;
            }
            _userRepository.UpdateUser(oldUser);

            return _mapper.Map<UserUpdateOutDTO>(oldUser);
        }      

        
    }
}
