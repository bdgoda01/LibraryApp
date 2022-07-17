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

            //intro, ask user for name of book, display book information
            Console.WriteLine("Welcome to Big Bean's Library!");
            Console.WriteLine("These are our currently available books:\n");

            //temporary, get array of all book names
            List<string> allBookNames = libraryBooks.GetBookNames();
            foreach (string bookName in allBookNames)
            {
                Console.WriteLine(bookName);
            }

            Console.WriteLine("\nWhich book would you like to know more about?");
            string bookSelection = Console.ReadLine();
            bool bookExists = allBookNames.Exists(bookName => bookName == bookSelection);
            if (bookExists)
            {
                libraryBooks.Lookup(bookSelection);
            }
            else
            {
                Console.WriteLine("Invalid Selection. Goodbye.");
            }

        }
    }
}