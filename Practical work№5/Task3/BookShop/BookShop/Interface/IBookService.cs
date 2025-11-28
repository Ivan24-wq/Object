using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Models;

namespace BookShop.Interface
{
    public interface IBookService
    {
        void AddBook(Book book); //Добавляем книгу в систему
        void DeleteBook(int id); //Удаляем книгу из системы
        Book GetBook(int id);    //Добавляем книгу в систему
        IEnumerable<Book> GetAll();  //Возврат всех книг
        IEnumerable<Book> SearchByTitle(string title);  //Поиск книги по названию
    }
}
