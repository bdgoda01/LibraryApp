using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int ReleaseYear { get; private set; }
        public List<string> Genre { get; private set; }

        public Book(string title, string author, int releaseYear, List<string> genre)
        {
            Title = title;
            Author = author;
            ReleaseYear = releaseYear;
            Genre = genre;
        }

        public string DisplayInfo()
        {
            string genres = string.Join(", ", Genre);
            
            return $"{Title} by {Author}\nRelease Year: {ReleaseYear}\nGenre(s): {genres}";
        }
    }
}
