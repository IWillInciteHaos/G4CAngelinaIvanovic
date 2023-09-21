namespace ProjekatNaVezbama.DTO
{
    public class UserUpdateOutDTO
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserUpdateOutDTO()
        {
            Username = "";
            Password = "";
            Email = "";
        }
    }
}
