using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int ReleaseYear { get; private set; }
        public List<string> Genre { get; private set; }
        public string Loanee { get; private set; }
        public bool IsAvailable => (String.IsNullOrEmpty(Loanee));
        public string IsAvailableString => IsAvailable ? "Available" : "On Loan";

        public Book(string title, string author, int releaseYear, List<string> genre)
        {
            Title = title;
            Author = author;
            ReleaseYear = releaseYear;
            Genre = genre;
        }

        public void CheckOutBook(string loaneeName)
        {
            if (IsAvailable)
            {
                Loanee = loaneeName;
                Console.WriteLine("Thanks, {0}! You have sucessfully checked out this book.", loaneeName);
            }
            else
            {
                Console.WriteLine("Sorry, this book has been checked out.");
            }
        }

        public void ReturnBook(string loaneeName)
        {
            if (!IsAvailable && Loanee == loaneeName)
            {
                Loanee = null;
                Console.WriteLine("You have successfully returned this book.");
            }
            else if (!IsAvailable && Loanee != loaneeName)
            {
                Console.WriteLine("Sorry, this book was checked out by someone else.");
            }
            else
            {
                Console.WriteLine("This book has not been checked out.");
            }
        }
        public string DisplayInfo()
        {
            string genres = string.Join(", ", Genre);
            
            return $"{Title} by {Author}\nRelease Year: {ReleaseYear}\nGenre(s): {genres}\nStatus: {IsAvailableString}";
        }
    }
}
