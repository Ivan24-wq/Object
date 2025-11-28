using BookShop.Interface;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.UI
{
    public class Menu
    {
        private readonly IBookService bookService;

        public Menu(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("\n=== КНИЖНЫЙ МАГАЗИН ===");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Показать все книги");
                Console.WriteLine("3. Найти книгу по названию");
                Console.WriteLine("4. Удалить книгу");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddBook(); break;
                    case "2": ShowAllBooks(); break;
                    case "3": SearchBook(); break;
                    case "4": RemoveBook(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный ввод."); break;
                }
            }
        }

        private void AddBook()
        {
            Console.Write("Название: ");
            string title = Console.ReadLine();

            Console.Write("Автор: ");
            string author = Console.ReadLine();

            Console.Write("Цена: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Количество: ");
            int quantity = int.Parse(Console.ReadLine());

            bookService.AddBook(new Book
            {
                Title = title,
                Author = author,
                Price = price,
                Quantity = quantity
            });

            Console.WriteLine("Книга добавлена!");
        }

        private void ShowAllBooks()
        {
            Console.WriteLine("\n=== Список книг ===");
            foreach (var b in bookService.GetAll())
            {
                Console.WriteLine($"{b.Id}. {b.Title} — {b.Author}, {b.Price}₽ ({b.Quantity} шт.)");
            }
        }

        private void SearchBook()
        {
            Console.Write("Введите название: ");
            string title = Console.ReadLine();

            var res = bookService.SearchByTitle(title);

            foreach (var b in res)
            {
                Console.WriteLine($"{b.Id}. {b.Title} – {b.Author}");
            }
        }

        private void RemoveBook()
        {
            Console.Write("ID книги для удаления: ");
            int id = int.Parse(Console.ReadLine());
            bookService.DeleteBook(id);
            Console.WriteLine("Книга удалена (если существовала).");
        }
    }
}

