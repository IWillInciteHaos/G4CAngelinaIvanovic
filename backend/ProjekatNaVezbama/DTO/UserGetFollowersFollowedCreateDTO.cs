using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.DTO
{
    public class UserGetFollowersFollowedCreateDTO
    {
        public int ID { get; set; }
        //is this needed or do I just think it looks pretty?
        //public string Username { get; set; }
        public bool ForFollowers { get; set; }
    }
}
