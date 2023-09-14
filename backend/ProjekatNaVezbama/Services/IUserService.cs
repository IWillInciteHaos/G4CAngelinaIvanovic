using ProjekatNaVezbama.DTO;
using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<UserOutDTO>> GetAllUsers();

        public Task<UserOutDTO> GetUser(int userID);
        public Task<UserOutDTO> CreateUser(UserCreateDTO userDTO);
        public Task<bool> DeleteUser(int id);
    }
}
