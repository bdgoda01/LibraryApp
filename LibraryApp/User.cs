using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class User
    {
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private string _userInput;

        public User(string userName, string firstName, string lastName)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
        }

        public User(string userName)
        {
            UserName = userName;

            //method to set up new users
            NewUserSetUp();
        }

        private void NewUserSetUp()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome, {0}!", UserName);
                Console.WriteLine("As a new user, please enter some information to finish setting up your library account.");

                while (true)
                {
                    Console.Write("\nFirst Name: ");
                    _userInput = Console.ReadLine();

                    //validate userInput
                    //maybe can create a separate validation class?
                    //eventually add conditions to prohibit numbers or special characters
                    if (String.IsNullOrEmpty(_userInput))
                    {
                        Console.WriteLine("\nFirst Name cannot be empty. Please enter a valid First Name.\n\n");
                        Console.Write("Press enter to try again... ");
                        Console.ReadLine();
                        Console.WriteLine("\n");
                        continue;
                    }

                    FirstName = _userInput;
                    Constants.ShortPause();

                    while (true)
                    {
                        Console.Write("\nLast Name: ");
                        _userInput = Console.ReadLine();

                        if (String.IsNullOrEmpty(_userInput))
                        {
                            Console.WriteLine("\nLast Name cannot be empty. Please enter a valid Last Name.\n\n");
                            Console.Write("Press enter to try again... ");
                            Console.ReadLine();
                            Console.WriteLine("\n");
                            continue;
                        }

                        LastName = _userInput;
                        Constants.ShortPause();
                        break;
                    }
                    break;
                }

                //confirmation
                Console.Clear();
                Console.WriteLine("\nPlease confirm the following is correct.");
                Console.WriteLine($"\nUsername: {UserName}\nFirst Name: {FirstName}\nLast Name: {LastName}");
                Console.Write("\nIf the information is incorrect, please enter 'NO'.\nOtherwise, please press enter: ");
                _userInput = Console.ReadLine();
                if (!String.IsNullOrEmpty(_userInput))
                {
                    Console.WriteLine("\nPlease enter your information again...");
                    Constants.MediumPause();
                    continue;
                }
                break;
                
            }
           


        }
    }
}
