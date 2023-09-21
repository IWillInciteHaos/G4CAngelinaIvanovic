namespace ProjekatNaVezbama.DTO
{
    public class UserFollowOutDTO
    {
        public UserOutDTO Follower { get; set; }
        public UserOutDTO UserToFollow { get; set; }
        public bool IsFollowing { get; set; }
        public UserFollowOutDTO()
        {
            Follower = new UserOutDTO();
            UserToFollow = new UserOutDTO();
        }
    }
}
