using Livraria.Domain;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infra
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=livraria.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var bookBuilder = modelBuilder.Entity<Book>();

            bookBuilder
                .Property(p => p.ID)
                .HasColumnName("id");

            bookBuilder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(300);

            bookBuilder.Property(p => p.Authors)
                .HasColumnName("authors")
                .HasMaxLength(300);

            bookBuilder.Property(p => p.PublishYear)
                .HasColumnName("publish_year")
                .IsRequired(false);

            bookBuilder.Property(p => p.Edition)
                .HasColumnName("edition")
                .HasMaxLength(100);

            bookBuilder.Property(p => p.ISBN)
                .HasColumnName("isbn")
                .HasMaxLength(13);

            bookBuilder.Property(p => p.Price)
                .HasColumnName("price");

            bookBuilder.Property(p => p.BuyDate)
                .HasColumnName("buy_date");

            bookBuilder.Property(p => p.BuyPrice)
                .HasColumnName("buy_price");

            bookBuilder.Property(p => p.SellDate)
                .HasColumnName("sell_date")
                .IsRequired(false);

            bookBuilder.Property(p => p.SellPrice)
                .HasColumnName("sell_price")
                .IsRequired(false);
        }

        public DbSet<Book> Books { get; set; }
    }
}
