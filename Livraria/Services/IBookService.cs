using System;
using System.Collections.Generic;
using Livraria.Domain;
using Livraria.Model;

namespace Livraria.Services
{
    public interface IBookService
    {
        IEnumerable<BookResponseViewModel> FindAll();
        IEnumerable<BookResponseViewModel> FindAllInStock();
        BookResponseViewModel FindById(int id);
        BookResponseViewModel Save(BookViewModel book);
        bool Delete(int id);
        BookResponseViewModel Sell(BookSellViewModel book);
    }
}