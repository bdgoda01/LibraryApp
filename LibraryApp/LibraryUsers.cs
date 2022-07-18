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

        public void GetUserNames()
        {
            
        }
    }
}
