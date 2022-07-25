using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class BookCollection
    {
        //holds collection of all books in the library
        private readonly Dictionary<int, Book> _bookCollection = new();

        //constructor: sets the _bookCollection dictionary
        public BookCollection(Dictionary<int, Book> bookCollection)
        {
            _bookCollection = bookCollection;
        }

        //displays each book number & title of all books in the library and adds titles to _bookTitles list
        public void DisplayAllBooks()
        {
            foreach (KeyValuePair<int, Book> record in _bookCollection)
            {
                int bookNumber = record.Key;
                Book book = record.Value;

                Console.Write("{0}: ", bookNumber);
                Console.WriteLine(book.Title);
            }
        }

        //looks up and displays a book's info based on user input
        public Book Lookup(string bookNumber)
        {
            if (!String.IsNullOrEmpty(bookNumber) && Int32.TryParse(bookNumber, out int bookKey))
            {
                if (_bookCollection.TryGetValue(bookKey, out Book book))
                {
                    return book;
                }
                else
                {
                    Console.WriteLine("\nThat number is not assigned to a book.");
                    Console.Write("Press enter to try again...");
                    Console.ReadLine();
                    return null;
                }
            }
            else
            {
                Console.WriteLine("\nA book number must be entered to proceed.");
                Console.Write("Press enter to try again...");
                Console.ReadLine();
                return null;
            }
        }

        //change constructor to accept array of Books instead and then assign key values based on some logic to assign it the next available number
        //add overload(?) so constructor can accept just one Book (instead of an array of them)
        //need to create an Add method to add books to dictionary (to add an array of books or just one book)
    }
}
