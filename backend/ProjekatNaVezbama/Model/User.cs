namespace ProjekatNaVezbama.Model
{
    public class User
    {
        public int ID { get; set; }
        //should be unique
        public string UsernameID { get; set; }
        public string Password { get; set; }
        //public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        List<User> Followers { get; set; }
        List<User> Following { get; set; }
        List<Post> Posts { get; set; }
        List<Post> LikedPosts { get; set; }
        List<Comment> Commented { get; set; }
        List<Comment> LikedComments { get; set; }
        
        public User() { }

        public User(string username, string password, string email)
        {
            UsernameID = username;
            Password = password;
            Email = email;
            Followers = new List<User>();
            Following = new List<User>();
            Posts = new List<Post>();
            LikedPosts = new List<Post>();
            Commented = new List<Comment>();
            LikedComments = new List<Comment>();

        }

        // da li bi bilo pametno ovo da se izmesti u UserRepo?
        public void FollowING(User u)
        {
            //follwow someone
            //Following.Add(u);
            Console.WriteLine("Following someone");
        }
        public void FollowED(User u)
        {
            //follwow someone
            Console.WriteLine("Follwed someone");
        }

        public void Post(Post p)
        {
            //make post
            //Posts.Add(p);
            Console.WriteLine("Made post");
        }
        public void PostLiked(Post p)
        {
            //like a post
            //LikedPosts.Add(p);
            Console.WriteLine("Liked a post");
        }

        public void Comment(Comment c)
        {
            //make a comment
            //Commented.Add(c);
            Console.WriteLine("Made comment");
        }
        
        public void CommentLiked(Comment c)
        {
            //make a comment
            //LikedComments.Add(c);   
            Console.WriteLine("Liked comment");
        }

        public void GetPosts(bool everything)
        {
            if (everything)
            {
                //get all posts
                Console.WriteLine("got all posts");
            }
            else
            {
                //get only my posts
                Console.WriteLine("got my posts");
            }
        }
    }
}
