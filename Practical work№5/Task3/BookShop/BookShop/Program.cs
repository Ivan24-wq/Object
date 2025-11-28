using BookShop.Data;
using BookShop.Interface;
using BookShop.Service;
using BookShop.UI;
using BookShop.Interface;
using BookShop.Service;
using BookShop.UI;

class Program
{
    static void Main()
    {
        IRepository<BookShop.Models.Book> repo = new InMemoryRepository<BookShop.Models.Book>();
        IBookService bookService = new BookService(repo);

        Menu menu = new Menu(bookService);
        menu.Start();
    }
}
