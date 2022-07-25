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
                LibraryStatic.MediumPause();
                Console.WriteLine("Successfully logged in.");
                Console.Write("Press enter to continue...");
                Console.ReadLine();
                return currentUser;
            }
            else
            {
                User newUser = new User(username);
                _libraryUsers.Add(username, newUser);
                return newUser;
            }
        }
    }
}
