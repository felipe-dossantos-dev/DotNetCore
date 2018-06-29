using System;
using System.Collections.Generic;
using Livraria.Domain;

namespace Livraria.Repositories
{
    public interface IBookRepository 
    {
        IEnumerable<Book> FindAll();
        IEnumerable<Book> FindAllInStock();
        Book FindById(int ID);
        Book Save(Book book);
        void Delete(Book ID);
    }
}