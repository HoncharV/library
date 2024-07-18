using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime ReleaseDate { get; set; }

    public Book(string title, string author, DateTime releaseDate)
    {
        Title = title;
        Author = author;
        ReleaseDate = releaseDate;
    }
}
public class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(string title)
    {
        Book bookToRemove = books.Find(b => b.Title == title);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
        }
        else
        {
            throw new Exception("Book not found.");//Книга не знайдена.
        }
    }

    public void ListBooks()
    {
        foreach (Book book in books)
        {
            Console.WriteLine($"Name: {book.Title}, Author: {book.Author}, ReleaseDate: {book.ReleaseDate.ToShortDateString()}");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1.Add a book");//Додати книгу
            Console.WriteLine("2.Delete the book");//Видалити книгу
            Console.WriteLine("3.Show all books");//Показати всі книги
            Console.WriteLine("4. Go out");//Вийти
            Console.Write("Select an option: ");//Виберіть опцію

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Enter a name: ");//Введіть назву
                    string title = Console.ReadLine();
                    Console.Write("Enter the author: ");//Введіть автора
                    string author = Console.ReadLine();
                    Console.Write("Enter the release date (dd/mm/yyyy): ");//Введіть дату випуску
                    DateTime releaseDate = DateTime.Parse(Console.ReadLine());
                    library.AddBook(new Book(title, author, releaseDate));
                    break;
                case 2:
                    Console.Write("Enter the name of the book to delete: ");//Введіть назву книги для видалення
                    string titleToRemove = Console.ReadLine();
                    try
                    {
                        library.RemoveBook(titleToRemove);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 3:
                    library.ListBooks();
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Wrong choice. Try again.");//Невірний вибір. Спробуйте ще раз
                    break;
            }
        }
    }
}












