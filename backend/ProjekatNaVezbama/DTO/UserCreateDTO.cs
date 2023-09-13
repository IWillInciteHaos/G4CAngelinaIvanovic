using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.DTO
{
    public class UserCreateDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        //public DateTime CreatedDate { get; set; }
        public string Email { get; set; }

        public UserCreateDTO(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public UserCreateDTO() { }


        public UserCreateDTO MakeUserCreatedDTO(User u)
        {
            UserCreateDTO ucdto = new UserCreateDTO();
            ucdto.Username = u.Username;
            ucdto.Password = u.Password;
            ucdto.Email = u.Email;

            return ucdto;
        }
        public User DTOCreatedUser()
        {
            return new User(Username, Password, Email);

        }
    }
}
