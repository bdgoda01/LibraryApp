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
            {"2", "Log Out" }
        };

        private Dictionary<string, string> _postLogOutMenu = new Dictionary<string, string>
        {
            {"1", "Log In" },
            {"2", "Exit Application" }
        };

        private Dictionary<string, string> _browseCollectionMenu = new Dictionary<string, string>
        {
            {"1", "Select a Book" },
            {"2", "Return to Main Menu" }
        };

        private Dictionary<string, string> _bookInfoMenu = new Dictionary<string, string>
        {
            {"1", "Check Out Book" },
            {"2", "Return to Book List" },
            {"3", "Return to Main Menu" }
        };

        private Dictionary<string, string> _postCheckOutMenu = new Dictionary<string, string>
        {
            {"1", "Return to Book List" },
            {"2", "Return to Main Menu" }
        };

        public Menu(User currentUser, BookCollection libraryBooks)
        {
            _currentUser = currentUser;
            _libraryBooks = libraryBooks;
        }

        public bool LibraryMenu()
        {
            while (true)
            {
                Console.Clear();
                DisplayMenu(_libraryMainMenu);
                _userInput = Console.ReadLine();
                
                if (CheckMenuSelection(_userInput, _libraryMainMenu))
                {
                   bool continueMainMenuLoop = MainMenu(_userInput);
                   if (continueMainMenuLoop)
                   {
                        continue;
                   }
                }
                else
                {
                    continue;
                }

                if (LogOut())
                {
                    //log out and restart
                    return true;
                }
                else
                {
                    //log out and exit application
                    return false;
                }

            }

        }

        private void DisplayMenu(Dictionary<string, string> menu)
        {
            Console.WriteLine("Would you like to: \n");
            foreach(KeyValuePair<string, string> menuItem in menu)
            {
                string menuNumber = menuItem.Key;
                string menuName = menuItem.Value;

                Console.WriteLine("{0}: {1}", menuNumber, menuName);
            }
            Console.WriteLine();
        }

        private bool MainMenu(string userMenuSelection)
        {
            //returns true to restart Main Menu loop
            //returns false to start Log Out process

            if(userMenuSelection == "1")
            {
                BrowseCollection();
                return true;
            }
            else if (userMenuSelection == "2")
            {
                return false;
            }

            return true;
            
        }

        private bool CheckMenuSelection(string userInput, Dictionary<string, string> menu)
        {
            //returns true if user input is a valid menu selection

            if(!string.IsNullOrEmpty(userInput) && menu.TryGetValue(userInput, out _))
            {
                return true;
            } 
            else if (!string.IsNullOrEmpty(userInput) && !menu.TryGetValue(userInput, out _))
            {
                Console.WriteLine("\nInvalid menu selection.");
                Console.Write("Press enter to try again...");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine("\nA menu option must be entered to proceed.");
                Console.Write("Press enter to try again...");
                Console.ReadLine();
                return false;
            }
            
        }

        private void BrowseCollection()
        {
            while (true)
            {
                DisplayLibraryCollection();
                Console.WriteLine();
                DisplayMenu(_browseCollectionMenu);
                _userInput = Console.ReadLine();

                if (CheckMenuSelection(_userInput, _browseCollectionMenu))
                {
                    if(_userInput == "1")
                    {
                        bool continueBrowseLoop = LookupBook();
                        if (continueBrowseLoop)
                        {
                            //Displays all books again
                            continue;
                        }
                        else
                        {
                            //returns to Main Menu
                            break;
                        }

                    }
                    else
                    {
                        //returns to Main Menu
                        break;
                    }
                }
                else
                {
                    //Displays all books again
                    continue;
                }
            }
           
        }

        private void DisplayLibraryCollection()
        {
            Console.Clear();
            _libraryBooks.DisplayAllBooks();
            Console.WriteLine();
        }

        private bool LookupBook()
        {
            while (true)
            {
                Console.Write("\nPlease enter a book number: ");
                _userInput = Console.ReadLine();
                Book bookSelection = _libraryBooks.Lookup(_userInput);
                if (bookSelection is not null)
                {
                    //DisplayBookInfo returns false to return to main menu or returns true to display books again
                    bool continueBrowseLoop = DisplayBookInfo(bookSelection);
                    return continueBrowseLoop;
                }
                else
                {
                    DisplayLibraryCollection();
                    continue;
                }
            }
        }

        private bool DisplayBookInfo(Book userBookSelection)
        {
            //return true to display all books again
            //return false to return to main menu
            while (true)
            {
                Console.Clear();
                Console.WriteLine(userBookSelection.DisplayInfo());
                Console.WriteLine();

                DisplayMenu(_bookInfoMenu);
                _userInput = Console.ReadLine();

                if (CheckMenuSelection(_userInput, _bookInfoMenu))
                {
                    if(_userInput == "1")
                    {
                        bool continueBrowseLoop = CheckOut(userBookSelection);
                        return continueBrowseLoop;
                    }
                    else if (_userInput == "2")
                    {
                        return true;
                    }
                    else if (_userInput == "3")
                    {
                        return false;
                    }

                    continue;
                    //should not reach this continue
                }
                else
                {
                    continue;
                }
            }

        }

        private bool CheckOut(Book userBookSelection)
        {
            userBookSelection.CheckOutBook(_currentUser.FullName);

            while (true)
            {
                DisplayMenu(_postCheckOutMenu);
                _userInput = Console.ReadLine();

                if (CheckMenuSelection(_userInput, _postCheckOutMenu))
                {
                    if(_userInput == "1")
                    {
                        //returns true to display all books again
                        return true;
                    }
                    else
                    {
                        //returns false to return to menu
                        return false;
                    }
                }
                else
                {
                    continue;
                }
            }

        }
        private bool LogOut()
        {
            //log out and determine if user wants to exit app or restart
            Console.Clear();
            Console.WriteLine("Thank you for visiting Big Bean's Library, {0}!", _currentUser.FirstName);
            Console.WriteLine("\nLogging you out, {0}...", _currentUser.UserName);
            LibraryStatic.MediumPause();
            Console.WriteLine("...");
            LibraryStatic.ShortPause();
            Console.WriteLine("Logged out successfully.");
            Console.Write("Press Enter to continue: ");
            Console.ReadLine();

            while (true)
            {
                Console.Clear();
                DisplayMenu(_postLogOutMenu);
                _userInput = Console.ReadLine();
                if (CheckMenuSelection(_userInput, _postLogOutMenu))
                {
                    if(_userInput == "1")
                    {
                        //returns true to restart application (log in again)
                        return true;
                    }
                    else
                    {
                        //returns false to exit application
                        return false;
                    }
                }
                else
                {
                    continue;
                }
            }

        }
    }
}
