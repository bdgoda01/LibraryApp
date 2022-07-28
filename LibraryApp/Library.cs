using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LibraryApp
{
    public class Library
    {
        private Dictionary<int, Book> _booksDatabase = new Dictionary<int, Book>();
        private BookCollection _libraryBooks;
        private LibraryUsers _allUsers;
        private User _currentUser;
        private Menu _libraryMenus;
        
        public Library()
        {
            InitializeLibraryBooks();

            _libraryBooks = new BookCollection(_booksDatabase);

            User user1 = new User("libraryAdmin", "Library", "Admin");
            User user2 = new User("beanieBaby", "Beanie", "Baby");

            _allUsers = new LibraryUsers
                (
                    new Dictionary<string, User>
                    {
                        { user1.UserName, user1 },
                        { user2.UserName, user2 }
                    }
                );
        }

        public void InitializeLibraryBooks()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "librarybooks.json");

            var serializer = new JsonSerializer();

            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                _booksDatabase = serializer.Deserialize<Dictionary<int, Book>>(jsonReader);
            }

        }

        public void AppStart()
        {
            while (true)
            {
                Console.Clear();
                Intro();
                _currentUser = LogIn();
                _libraryMenus = new Menu(_currentUser, _libraryBooks);
                bool continueProgramLoop = _libraryMenus.LibraryMenu();
                if (continueProgramLoop)
                {
                    _currentUser = null;
                    _libraryMenus = null;
                    continue;
                }
                else
                {
                    break;
                }
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
