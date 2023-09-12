using Microsoft.IdentityModel.Tokens;
using ProjekatNaVezbama.DB;
using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBPostItContext _repository;
        public UserRepository(DBPostItContext repository)
        {
            _repository = repository;
        }

        public bool CreateUser(string userID, string password, string email)
        {
            bool retVal = false;
            //Check if the username is taken
            if (!_repository.Users.Where(user => user.UsernameID.Equals(userID)).Any())
            {
                //check if the email is valid
                //do{ //req input }while(email.Contains('@') || !email.IsNullOrEmpty())
                if (email.Contains('@') && !email.IsNullOrEmpty())
                {
                    _repository.Users.Add(new User(userID, password, email));
                    retVal = true;
                }
            }
            return retVal;
        }

        public bool DeleteUser(string userID)
        {
            bool retVal = false;
            //Check if the username is taken
            if (!_repository.Users.Where(user => user.UsernameID.Equals(userID)).Any())
            {
                User u = (User)_repository.Users.Where(user => user.UsernameID.Equals(userID)).FirstOrDefault();
                _repository.Users.Remove(u);
                retVal = true;

            }
            return retVal;
        }

        public List<User> GetAllUsers()
        {
            // get all users or say nah
            List<User> retVal = new List<User>();
            if (_repository.Users.Any())
            {
                retVal = (List<User>)_repository.Users.Select(u => u.ID);
            }

            return retVal;
        }

        public User GetUser(string userID)
        {
            User retVal = null;
            //Check if the username is taken
            if (_repository.Users.Where(user => user.UsernameID.Equals(userID)).Any())
            {
                retVal = (User)_repository.Users.Where(user => user.UsernameID.Equals(userID)).FirstOrDefault();
            }

            return retVal;
        }

        public bool UpdateUser(
                string userID,
                string password = "", 
                string email = "", 
                User addFollower = null,
                User followAnother = null,
                Post newPost = null, 
                Post likedPost = null, 
                Comment likedComment = null)
        {

            bool retVal = false;

            //check if there is such user
            if (!_repository.Users.Where(user => user.UsernameID.Equals(userID)).Any())
            {
                return retVal;
            }

            //check for error?
            User tempUser = _repository.Users.Where(u => u.UsernameID.CompareTo(userID) == 0).FirstOrDefault();

            bool[] changes = new bool[7];

            changes[0] = email.IsNullOrEmpty() ? false : true;
            changes[1] = password.IsNullOrEmpty() ? false : true;
            changes[2] = addFollower == null ? false : true;
            changes[3] = followAnother == null ? false : true;
            changes[4] = newPost == null ? false : true;
            changes[5] = likedPost == null ? false : true;
            changes[6] = likedComment == null ? false : true;

            //all are empty?
            /*if(!changes.All(x => x))
            {
                Console.WriteLine("No changes to be made, why you even here? #Empty Change User#");
                return retVal;
            }*/


            
            for (int i = 0; i < changes.Length; i++)
            {
                if (changes[i])
                {
                    switch (i)
                    {
                        //change mail
                        case 0:
                            tempUser.Email = email;
                            retVal = true;
                            break;
                        //change password
                        case 1:
                            tempUser.Password = password;
                            retVal = true;
                            break;
                        //add follower
                        case 2:
                            tempUser.FollowED(addFollower);
                            retVal = true;
                            break;
                        //follow another
                        case 3:
                            tempUser.FollowING(followAnother);
                            retVal = true;
                            break;
                        //new post
                        case 4:
                            tempUser.Post(newPost);
                            retVal = true;
                            break;
                        //liked post
                        case 5:
                            tempUser.PostLiked(likedPost);
                            retVal = true;
                            break;
                        //liked comment
                        case 6:
                            tempUser.CommentLiked(likedComment);
                            retVal = true;
                            break;
                        default:
                            Console.WriteLine("What are you doing here? #UpdateUserError#");
                            break;
                    }
                }
            }

            //return user to the database

            return retVal;
        }
    }
}
