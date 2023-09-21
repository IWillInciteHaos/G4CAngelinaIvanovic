using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.DTO
{
    public class UserGetFollowerFollowersOutDTO
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public UserGetFollowerFollowersOutDTO()
        {

        }
        public UserGetFollowerFollowersOutDTO(int id)
        {
            ID = id;
        }
    }
}
