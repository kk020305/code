using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }

        public Book(string id, string title, string author, int yearPublished)
        {
            Id = id;
            Title = title;
            Author = author;
            YearPublished = yearPublished;
        }

        public override string ToString()
        {
            return $"{Title} by {Author} ({YearPublished}) [ID: {Id}]";
        }
    }

    public class Library
    {
        private List<Book> Books { get; set; }

        public Library()
        {
            Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Книга '{book.Title}' добавлена в библиотеку.");
        }

        public void RemoveBook(string bookId)
        {
            var bookToRemove = Books.FirstOrDefault(b => b.Id == bookId);
            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
                Console.WriteLine($"Книга '{bookToRemove.Title}' удалена из библиотеки.");
            }
            else
            {
                Console.WriteLine("Книга с указанным идентификатором не найдена.");
            }
        }

        public Book GetBook(string bookId)
        {
            return Books.FirstOrDefault(b => b.Id == bookId);
        }

        public List<Book> GetAllBooks()
        {
            return Books;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book("1", "Маленький принц", "Антуан де Сент-Экзюпери", 1942));
            library.AddBook(new Book("2", "Война и мир", "Л.Н.Толстой", 1867));
            library.AddBook(new Book("3", "Капитал", "Карл Маркс", 1866));

            Console.WriteLine("Все книги в библиотеке:");
            foreach (var book in library.GetAllBooks())
            {
                Console.WriteLine(book);
            }

            library.RemoveBook("2");

            var bookById = library.GetBook("1");
            if (bookById != null)
            {
                Console.WriteLine($"Найдена книга: {bookById}");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }
    }
}

