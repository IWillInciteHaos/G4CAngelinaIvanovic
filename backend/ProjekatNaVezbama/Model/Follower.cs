namespace ProjekatNaVezbama.Model
{
    public class Follower
    {
        public int FollowingID { get; set; }
        public int ID { get; set; }
        public User User { get; set; }
        public List<User> ToFollow { get; set; }
        //public List<int> ToFollowID { get; set; }

        public Follower()
        {
            ToFollow = new List<User>();
        }
        public Follower(User user)
        {
            FollowingID = user.ID;
            User = user;
            ToFollow = new List<User>();

        }
    }
}
