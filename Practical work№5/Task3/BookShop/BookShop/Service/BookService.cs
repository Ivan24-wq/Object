using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.Interface;
using BookShop.Models;

namespace BookShop.Service
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> repository;

        public BookService(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public void AddBook(Book book) => repository.Add(book);

        public void DeleteBook(int id) => repository.Delete(id);

        public Book GetBook(int id) => repository.Get(id);

        public IEnumerable<Book> GetAll() => repository.GetAll();

        public IEnumerable<Book> SearchByTitle(string title)
        {
            return repository.GetAll()
                .Where(b => b.Title != null &&
                            b.Title.ToLower().Contains(title.ToLower()));
        }


    }
}
