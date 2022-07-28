using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class BookCollection
    {
        private readonly Dictionary<int, Book> _bookCollection = new();

        public BookCollection(Dictionary<int, Book> bookCollection)
        {
            _bookCollection = bookCollection;
        }

        public void DisplayAllBooks()
        {
            foreach (KeyValuePair<int, Book> record in _bookCollection)
            {
                int bookNumber = record.Key;
                Book book = record.Value;

                Console.WriteLine("{0}: {1}", bookNumber, book.Title);
            }
        }

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
    }
}
