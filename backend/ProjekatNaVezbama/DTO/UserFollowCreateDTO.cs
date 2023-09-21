namespace ProjekatNaVezbama.DTO
{
    public class UserFollowCreateDTO
    {
        public int FollowerID { get; set; }
        public string Follower { get; set; }
        public int UserToFollowID { get; set; }
        public string UserToFollow { get; set; }
    }
}
