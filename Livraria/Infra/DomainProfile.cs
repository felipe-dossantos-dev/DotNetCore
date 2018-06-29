using System;
using System.Collections.Generic;
using AutoMapper;
using Livraria.Domain;
using Livraria.Model;

namespace Livraria.Infra
{
    public class DomainProfile : Profile 
    {
        public DomainProfile() 
        {
            // domain -> vm
            CreateMap<Book, BookResponseViewModel>();

            // vm -> domain
            CreateMap<BookViewModel, Book>();
            CreateMap<BookSellViewModel, Book>();
        }
    }

}
