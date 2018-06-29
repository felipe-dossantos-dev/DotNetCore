using System;
using System.Collections.Generic;

namespace Livraria.Domain
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Authors { get;set; }
        public int? PublishYear { get; set; }
        public string Edition { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set;}
        public DateTime BuyDate { get; set; }
        public decimal BuyPrice { get; set; }
        public DateTime? SellDate { get; set; }
        public decimal? SellPrice { get; set; }
    }
}