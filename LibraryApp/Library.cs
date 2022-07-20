using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Library
    {
        private BookCollection _libraryBooks;
        private LibraryUsers _allUsers;
        private User _currentUser;
        private Menu _libraryMenus;
        
        public Library()
        {
            //initializing Library
            //temporary, create all books
            Book book1 = new Book("Twilight", "Stephenie Meyer", 2005, new List<string> { "YA", "Fantasy", "Romance" });
            Book book2 = new Book("New Moon", "Stephenie Meyer", 2006, new List<string> { "YA", "Fantasy", "Romance" });
            Book book3 = new Book("Eclipse", "Stephenie Meyer", 2007, new List<string> { "YA", "Fantasy", "Romance" });
            Book book4 = new Book("Breaking Dawn", "Stephenie Meyer", 2008, new List<string> { "YA", "Fantasy", "Romance" });

            //temporary, create bookCollection
            _libraryBooks = new BookCollection
                (
                    new Dictionary<int, Book>
                    {
                        { 1, book1 },
                        { 2, book2 },
                        { 3, book3 },
                        { 4, book4 }
                    }
                );

            //temporary, create user
            User user1 = new User("libraryAdmin", "Library", "Admin");
            User user2 = new User("beanieBaby", "Beanie", "Baby");

            //temporary, create LibraryUsers dictionary
            LibraryUsers allUsers = new LibraryUsers
                (
                    new Dictionary<string, User>
                    {
                        { user1.UserName, user1 },
                        { user2.UserName, user2 }
                    }
                );
        }

        public void AppStart()
        {
            while (true)
            {
                Intro();
                _currentUser = LogIn();
                _libraryMenus = new Menu(_currentUser, _libraryBooks);
                bool continueLoop = _libraryMenus.LibraryMenu();
                if (continueLoop)
                {
                    //true = log-in again
                    //false = exit application
                    _currentUser = null;
                    continue;
                }

                break;
            }
            
        }

        private void Intro()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Big Bean's Library!");
            Console.Write("Press Enter to continue: ");
            Console.ReadLine();
            Console.WriteLine();
        }

        private User LogIn()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Please enter your username: ");
                string userInput = Console.ReadLine();
                if (ValidateUserName(userInput))
                {
                    return _allUsers.UserExistsCheck(userInput);
                }
                continue;
            }

        }

        private bool ValidateUserName(string userInput)
        {
            if (!(String.IsNullOrEmpty(userInput) || Int32.TryParse(userInput, out _)))
            {
                return true;
            }
            else if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("\nA username must be entered to access the library.");
                Console.Write("Press enter to try again...");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine("\n'{0}' is not a valid username. Usernames cannot contain only numbers.\nA valid username must be entered to access the library.", userInput);
                Console.Write("Press enter to try again...");
                Console.ReadLine();
                return false;
            }
        }
    }
}
