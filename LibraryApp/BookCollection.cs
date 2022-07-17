using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    internal class BookCollection
    {
        private readonly Dictionary<int, Book> _bookCollection = new Dictionary<int, Book>();
        private readonly List<string> _bookNames = new List<string>();

        public BookCollection(Dictionary<int, Book> bookCollection)
        {
            _bookCollection = bookCollection;
        }

        public List<string> GetBookNames()
        {
            foreach(Book book in _bookCollection.Values)
            {
                _bookNames.Add(book.Title);
            }

            return _bookNames;
        }

        public void Lookup(string bookName)
        {
            foreach(Book book in _bookCollection.Values)
            {
                if(book.Title == bookName)
                {
                    Console.WriteLine(book.DisplayInfo());
                }
            }
        }

        //change constructor to accept array of Books instead and then assign key values based on some logic to assign it the next available number
        //add overload(?) so constructor can accept just one Book (instead of an array of them)
        //need to create an Add method to add books to dictionary (to add an array of books or just one book)
    }
}
