using System;
using System.Collections.Generic;
using AutoMapper;
using Livraria.Domain;
using Livraria.Model;
using Livraria.Repositories;

namespace Livraria.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _repository = bookRepository;
            _mapper = mapper;
        }

        public bool Delete(int id)
        {
            var dbBook = _repository.FindById(id);
            if (dbBook == null)
            {
                return false;
            }
            _repository.Delete(dbBook);
            return true;
        }

        public IEnumerable<BookResponseViewModel> FindAll()
        {
            return _mapper.Map<IEnumerable<BookResponseViewModel>>(_repository.FindAll());
        }

        public IEnumerable<BookResponseViewModel> FindAllInStock()
        {
            return _mapper.Map<IEnumerable<BookResponseViewModel>>(_repository.FindAllInStock());
        }

        public BookResponseViewModel FindById(int id)
        {
            return _mapper.Map<BookResponseViewModel>(_repository.FindById(id));
        }

        public BookResponseViewModel Save(BookViewModel book)
        {
            var dbBook = _repository.FindById(book.ID);
            if (dbBook == null)
            {
                dbBook = _mapper.Map<Book>(book);
            }
            else 
            {
                dbBook = _mapper.Map<BookViewModel, Book>(book, dbBook);
            }
            dbBook = _repository.Save(dbBook);
            return _mapper.Map<BookResponseViewModel>(dbBook);
        }

        public BookResponseViewModel Sell(BookSellViewModel book)
        {
            var dbBook = _repository.FindById(book.ID);
            if (dbBook == null)
            {
                return null;
            }
            dbBook = _mapper.Map<BookSellViewModel, Book>(book, dbBook);
            dbBook = _repository.Save(dbBook);
            return _mapper.Map<BookResponseViewModel>(dbBook);
        }
    }
}