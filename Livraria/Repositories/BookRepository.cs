using System;
using System.Collections.Generic;
using System.Linq;
using Livraria.Domain;
using Livraria.Infra;

namespace Livraria.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LivrariaContext _context;

        public BookRepository(LivrariaContext context)
        {
            _context = context;
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> FindAll()
        {
            return _context.Books.AsEnumerable().OrderBy(b => b.Name);
        }

        public IEnumerable<Book> FindAllInStock()
        {
            return _context.Books.Where(b => b.SellDate == null).OrderBy(b => b.Name);
        }

        public Book FindById(int ID)
        {
            return _context.Books
                    .Where(b => b.ID == ID)
                    .FirstOrDefault();
        }

        public Book Save(Book book)
        {
            if (book.ID == 0) {
                _context.Books.Add(book);
            }
            _context.SaveChanges();
            return book;
        }
    }
}