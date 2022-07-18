namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //collection of books
            //dictionary<int, Book> in BookCollection class
            //bookID, Book
            //Book > title, author, releaseYear, list of genres
            //method in BookCollection to get array of key values in the dictionary, take the max, add 1, assign that as the key value for books that are added in the future (if the dictionary is empty, assign 1 as the key value)
            //search for a book & display info


            //initializing Library
            //temporary, create all books
            Book book1 = new Book("Twilight", "Stephenie Meyer", 2005, new List<string> { "YA", "Fantasy", "Romance" });
            Book book2 = new Book("New Moon", "Stephenie Meyer", 2006, new List<string> { "YA", "Fantasy", "Romance" });
            Book book3 = new Book("Eclipse", "Stephenie Meyer", 2007, new List<string> { "YA", "Fantasy", "Romance" });
            Book book4 = new Book("Breaking Dawn", "Stephenie Meyer", 2008, new List<string> { "YA", "Fantasy", "Romance" });

            //temporary, create bookCollection
            BookCollection libraryBooks = new BookCollection
                (
                    new Dictionary<int, Book>
                    {
                        { 1, book1 },
                        { 2, book2 },
                        { 3, book3 },
                        { 4, book4 }
                    }
                );

            //temporary, create empty user
            User currentUser;

            //temporary, create empty LibraryUsers

            //const for sleep length
            const int pause = 3000;

            //program master loop
            while (true)
            {
                //intro
                Console.Clear();
                Console.WriteLine("Welcome to Big Bean's Library!\n");

                //gather user information, eventually separate class, eventually possibly add dictionary of all users?? or at least, a list
                //user class: userName, firstName, lastName, fullName
                //libraryUsers class: dictionary of all usernames and user object
                //after entering userName, if userName is not in dictionary, ask for firstName & lastName
                //if userName is in dictionary, log in, welcome with fullName
                while (true)
                {
                    Console.Write("Please enter your username: ");
                    string userInput = Console.ReadLine();
                    //eventually change if conditions into a checkUser/userConditions method or something
                    //maybe also add a length requirement and prohibit special characters
                    if (!(String.IsNullOrEmpty(userInput) || Int32.TryParse(userInput, out _)))
                    {
                        currentUser = new User(userInput);
                        break;

                    }
                    else if (String.IsNullOrEmpty(userInput))
                    {
                        Console.WriteLine("\nA username must be entered to access the library.");
                        Console.Write("Press enter to try again...");
                        Console.ReadLine();
                        Console.WriteLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("\n'{0}' is not a valid username. Usernames cannot contain only numbers.\nA valid username must be entered to access the library.", userInput);
                        Console.Write("Press enter to try again...");
                        Console.ReadLine();
                        Console.WriteLine();
                        continue;
                    }
                }

                //temporary process, will be changed to show menu of options first, then will display genres, then available books, then after viewing book info, user will choose an option from another menu
                Console.Clear();
                Console.WriteLine("These are our currently available books:\n");

                //displays all books
                libraryBooks.GetBookTitles();

                //asks user for book number, displays book info
                Console.WriteLine("\nWhich book would you like to know more about?");
                Console.Write("\nPlease enter the number of the book you are interested in: ");
                libraryBooks.Lookup(Console.ReadLine());

                //log out process
                //will add so user is asked if want to log out
                Console.WriteLine("\nPress enter to log out.");
                Console.ReadLine();
                Console.WriteLine("Logging you out...");
                Constants.MediumPause();
                Console.WriteLine("...");
                Constants.ShortPause();
                Console.WriteLine("Logged out successfully. Please visit our library again.");

                break;
            }
        }
    }
}