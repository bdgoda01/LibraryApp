using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }
        public List<string> Genre { get; set; }

        public Book(string title, string author, int releaseYear, List<string> genre)
        {
            Title = title;
            Author = author;
            ReleaseYear = releaseYear;
            Genre = genre;
        }

        public string DisplayInfo()
        {
            string genres = string.Join(",", Genre);
            
            return $"{Title} by {Author}\nRelease Year: {ReleaseYear}\nGenre(s): {genres}";
        }
    }
}
