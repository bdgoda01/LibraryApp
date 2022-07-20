using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//need to add Browse Collection ability
//need to add more Main Menu options
namespace LibraryApp
{
    public class Menu
    {
        private string _userInput;
        private User _currentUser;
        private BookCollection _libraryBooks;

        private Dictionary<string, string> _libraryMainMenu = new Dictionary<string, string>
        {
            {"1", "Browse Collection"},
            {"0", "Log Out" }
        };
        private Dictionary<string, string> _postLogOutMenu = new Dictionary<string, string>
        {
            {"1", "Log In" },
            {"0", "Exit Application" }
        };

        public Menu(User currentUser, BookCollection libraryBooks)
        {
            _currentUser = currentUser;
            _libraryBooks = libraryBooks;
        }

        public bool LibraryMenu()
        {
            int libraryMenuLevel = 2;
            LibraryStatic.programLevel += 1;
            
            while (true)
            {
                DisplayMenu(_libraryMainMenu);
                _userInput = Console.ReadLine();
                
                if (CheckMenuSelection(_userInput, _libraryMainMenu))
                {
                    bool continueProgramLoop = MainMenu(_userInput);
                    //valid menu selection
                    //cycle through main menu options
                    if (!continueProgramLoop && LibraryStatic.programLevel == libraryMenuLevel)
                    {
                        continue;
                    }
                    else if (continueProgramLoop)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
                continue; 
            }

            //figure out structure again lmao
            //
            //
            //
            //
            //
            //
            //
            //
            //
            //

            //User Input
            //if( input == 1)
            ////while loop{
            //////display all books
            //////enter 0 to go back to main menu
            //////user input for book they are interested in, or 0 to go back to main menu & break;
            //////display book info
            //////display book menu (check out book, return book, go back to all book display)
            ////////if(check out book) >> CheckOut; continue;
            ////////if(return) >> Return; continue;
            ////////if(go back) >> continue;
            ////}
            //if( input == 0)
            ////Log out; Display post-log out menu
            ////if( input == 1 ) 
            //////break;
            ////if( input == 0 )
            /////Environment.Exit(0)
        }

        private void DisplayMenu(Dictionary<string, string> menu)
        {
            Console.WriteLine("\nWould you like to: \n");
            foreach(KeyValuePair<string, string> menuItem in menu)
            {
                string menuNumber = menuItem.Key;
                string menuName = menuItem.Value;

                Console.WriteLine("{0}: {1}", menuNumber, menuName);
            }
        }

        private bool MainMenu(string userMenuSelection)
        {
            //don't need a loop, this is just to do if menu selection == #, then do a certain task
            //function stuff
            //set LibraryStatic.programLevel = level to return to
            //if LogOut() is true, return true; if false return false
            return true;
            
        }

        private bool CheckMenuSelection(string userInput, Dictionary<string, string> menu)
        {
            if(!string.IsNullOrEmpty(userInput) && menu.TryGetValue(userInput, out _))
            {
                return true;
            } 
            else if (!string.IsNullOrEmpty(userInput) && !menu.TryGetValue(userInput, out _))
            {
                //Invalid Menu Option
                return false;
            }
            else
            {
                //Enter a Menu Option
                return false;
            }
            
        }

        /*
        private void MenuSelection()
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
        */

        private bool LogOut()
        {
            //returns true to log out and restart and false to log out and exit
            //also should to set LibraryStatic.programLevel to 1 to loop master or 0 to exit
            //log out and determine if user wants to exit app or restart
            Console.Clear();
            Console.WriteLine("Thank you for visiting Big Bean's Library, {0}!", _currentUser.FirstName);
            Console.WriteLine("\nLogging you out, {0}...", _currentUser.UserName);
            LibraryStatic.MediumPause();
            Console.WriteLine("...");
            LibraryStatic.ShortPause();
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
                        LibraryStatic.ShortPause();
                        LibraryStatic.runProgram = false;
                        break;
                    }
                    else if (_userInput == "1")
                    {
                        //log in again
                        Console.WriteLine("Taking you back to Log In screen...");
                        LibraryStatic.ShortPause();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please provide a valid Menu Number...");
                        LibraryStatic.ShortPause();
                        Console.WriteLine();

                        continue;
                    }
                }
                else if (string.IsNullOrEmpty(_userInput))
                {
                    Console.WriteLine("Please provide a Menu Number...");
                    LibraryStatic.ShortPause();
                    Console.WriteLine();

                    continue;
                }
            }
            return true;
        }

    }
}
