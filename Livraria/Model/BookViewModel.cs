using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Model
{
    public class BookResponseViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Authors { get; set; }

        public int? PublishYear { get; set; }

        public String Edition { get; set; }

        public String ISBN { get; set; }

        public decimal Price { get; set; }

        public DateTime BuyDate { get; set; }

        public decimal BuyPrice { get; set; }

        public DateTime? SellDate { get; set; }

        public decimal? SellPrice { get; set; }
    }

    public class BookViewModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(300)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Authors { get; set; }

        public int? PublishYear { get; set; }

        [Required]
        [MaxLength(100)]
        public String Edition { get; set; }

        [Required]
        [MaxLength(13)]
        public String ISBN { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime BuyDate { get; set; }

        [Required]
        public decimal BuyPrice { get; set; }
    }

    public class BookSellViewModel 
    {
        [Required]
        public int ID { get; set; }
        
        [Required]
        public DateTime SellDate { get; set; }
        
        [Required]
        public decimal SellPrice { get; set; }   

    }
}