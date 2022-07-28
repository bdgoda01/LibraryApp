namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {         
            Library library = new Library();

            while (true)
            {
                library.AppStart();
                break;
            }
        }
    }
}