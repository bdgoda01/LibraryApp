//need to:
//need to add ability to check out books for users
//need to add way to keep track of books checked out by certain users 
//need to add an Available, a Loanee, and a ReturnDate property to Book object

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

            //initialize library
            Library library = new Library();

            //program master loop
            while (true)
            {
                library.AppStart();
                break;
            }
        }
    }
}