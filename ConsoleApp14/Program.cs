namespace ConsoleApp14
{
    class Program
    {
        static void Main()
        {
           // Console.WriteLine(Guid.NewGuid().ToString());

            Library library = new Library();
            var allBooks = library.GetBooks();

            foreach (Book book in allBooks)
            {
                Console.WriteLine(book.Info());
            }
            //Console.WriteLine($"Current book - {library.GetBook(allBooks[0].Id).Info()}");

            Console.WriteLine("\n\nAdd Book Area\n");
            library.AddBook(new Book("Greenligh", "Matthew McConauhey", 400, 300));
            allBooks = library.GetBooks();
            foreach (Book book in allBooks)
            {
                Console.WriteLine(book.Info());
            }

            Console.WriteLine("\n\nDelete Book Area\n\n");
            library.DeleteBook(allBooks[0].Id);
            allBooks = library.GetBooks();
            foreach (Book book in allBooks)
            {
                Console.WriteLine(book.Info());
            }

            Console.WriteLine("\n\nSort Book Area\n\n");
            library.SortByTitle();
            allBooks = library.GetBooks();
            foreach (Book book in allBooks)
            {
                Console.WriteLine(book.Info());
            }
        }
    }
    public class Library
    {
        private Book[] books;
        public Library()
        {
            books = new Book[2]
            {
                new Book("1984", "George Orwell", 390, 200),
                new Book("Atlas Shrugged", "Ayn Rand", 330, 360)
            };
        }
        public Book[] GetBooks() => books;
        public void AddBook(Book book)
        {
            Book[] books2 = new Book[books.Length + 1];
            for (int i = 0; i < books.Length; i++)
            {
                books2[i] = books[i];
            }
            books2[books2.Length - 1] = book;
            books = books2;
        }
        public Book? GetBook(string id)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Id.Equals(id))
                {
                    return books[i];
                }
            }
            return null;
        }
        public void DeleteBook(string id)
        {
            Book[] books2 = new Book[books.Length - 1];
            for (int i = 0, j = 0; i < books.Length; i++)
            {
                if (books[i].Id.Equals(id))
                {
                    continue;
                }
                books2[j++] = books[i];
            }
            books = books2;
        }
        public void SortByTitle()
        {
            var n = books.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (books[i].Title.CompareTo(books[j + 1].Title) > 0)
                    {
                        (books[j], books[j + 1]) = (books[j - 1], books[j]);
                    }
                }
            }
        }
    }
    public class Book
    {
        public string Id = Guid.NewGuid().ToString();
        public string Title;
        public string Author;
        public int Price;
        public int Pages;
        public Book(string title, string author, int price, int pages)
        {
            Title = title;
            Author = author;
            Price = price;
            Pages = pages;
        }
        public string Info() { return $"Id: {Id} Title: {Title} Author: {Author} Price: {Price} Pages: {Pages}"; }
    }
}
