using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//need to add Browse Collection ability
//need to add more Main Menu options
namespace LibraryApp
{
    static class Menu
    {
        private static string _userInput;
        private static User _currentUser;
        private static Dictionary<string, string> _libraryMainMenu = new Dictionary<string, string>
        {
            {"0", "Log Out" },
            {"1", "Browse Collection"}
        };
        private static Dictionary<string, string> _postLogOutMenu = new Dictionary<string, string>
        {
            {"0", "Exit Application" },
            {"1", "Log In" }
        };

        public static void Start(User currentUser)
        {
            _currentUser = currentUser;
            Console.WriteLine();
            DisplayMenu(_libraryMainMenu);
            MenuSelection();
        }

        private static void DisplayMenu(Dictionary<string, string> menu)
        {
            Console.WriteLine("\nWould you like to: \n");
            foreach(KeyValuePair<string, string> menuItem in menu)
            {
                string menuNumber = menuItem.Key;
                string menuName = menuItem.Value;

                Console.WriteLine("{0}: {1}", menuNumber, menuName);
            }
        }

        private static void MenuSelection()
        {
            while (true)
            {
                Console.Write("\nEnter Menu Number: ");
                _userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(_userInput) && Int32.TryParse(_userInput, out _ ))
                {
                    if(_userInput == "0")
                    {
                        LogOut();
                        Constants.runMenu = false;
                        break;
                    }
                    else if(_userInput == "1")
                    {
                        //browse collection
                        Console.WriteLine("Under Construction...");
                        Constants.ShortPause();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please provide a valid Menu Number...");
                        Constants.ShortPause();
                        Console.WriteLine();
                        continue;
                    }
                }
                else if (string.IsNullOrEmpty(_userInput))
                {
                    Console.WriteLine("Please provide a Menu Number...");
                    Constants.ShortPause();
                    Console.WriteLine();

                    continue;
                }
            }
            
        }

        private static void LogOut()
        {
            //log out and determine if user wants to exit app or restart
            Console.WriteLine("\n\nThank you for visiting Big Bean's Library, {0}!", _currentUser.FirstName);
            Console.WriteLine("\nLogging you out, {0}...", _currentUser.UserName);
            Constants.MediumPause();
            Console.WriteLine("...");
            Constants.ShortPause();
            Console.WriteLine("Logged out successfully.");
            
            DisplayMenu(_postLogOutMenu);

            while (true)
            {
                Console.Write("\nEnter Menu Number: ");
                _userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(_userInput) && Int32.TryParse(_userInput, out _))
                {
                    if (_userInput == "0")
                    {
                        //exit application
                        Console.WriteLine("Exiting Application. Goodbye!");
                        Constants.ShortPause();
                        Constants.runProgram = false;
                        break;
                    }
                    else if (_userInput == "1")
                    {
                        //log in again
                        Console.WriteLine("Taking you back to Log In screen...");
                        Constants.ShortPause();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please provide a valid Menu Number...");
                        Constants.ShortPause();
                        Console.WriteLine();

                        continue;
                    }
                }
                else if (string.IsNullOrEmpty(_userInput))
                {
                    Console.WriteLine("Please provide a Menu Number...");
                    Constants.ShortPause();
                    Console.WriteLine();

                    continue;
                }
            }
        }

    }
}
