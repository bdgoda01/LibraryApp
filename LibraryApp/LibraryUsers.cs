using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class LibraryUsers
    {
        //dictionary of all library users
        private readonly Dictionary<string, User> _libraryUsers = new();

        //list of usernames of all library users
        private List<string> _userNames => new List<string>(_libraryUsers.Keys);

        public LibraryUsers(Dictionary<string, User> libraryUsers)
        {
            _libraryUsers = libraryUsers;
        }

        public User UserExistsCheck(string username)
        {
            //Check if a user exists in the current database
            if(_libraryUsers.TryGetValue(username, out User currentUser))
            {
                Console.WriteLine("\nWelcome, {0} {1}! Logging you in...", currentUser.FirstName, currentUser.LastName);
                Constants.MediumPause();
                Console.WriteLine("Successfully logged in.");
                return currentUser;
            }
            else
            {
                User newUser = new User(username);
                return newUser;
            }
        }
    }
}
