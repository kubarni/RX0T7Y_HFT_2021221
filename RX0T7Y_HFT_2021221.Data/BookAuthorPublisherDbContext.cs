using Microsoft.EntityFrameworkCore;
using RX0T7Y_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RX0T7Y_HFT_2021221.Data
{
    public class BookAuthorPublisherDbContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public BookAuthorPublisherDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BookDatabase.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Book>(entity =>
            {
                entity
                .HasOne(book => book.Publisher)
                .WithMany(publisher => publisher.Books)
                .HasForeignKey(book => book.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            mb.Entity<Author>(entity =>
            {
                entity
                .HasOne(author => author.Publisher)
                .WithMany(publisher => publisher.Authors)
                .HasForeignKey(author => author.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            Publisher gabo = new Publisher() { Id = 1, Name = "Gabo könyvkiadó", Headquarters = "Budapest", Income = 35000000 };
            Publisher era = new Publisher() { Id = 2, Name = "erawan", Headquarters = "Székesfehérvár", Income = 1200000 };
            Publisher libri = new Publisher() { Id = 3, Name = "Librikiadó", Headquarters = "Budapest", Income = 41500000 };
            Publisher alexandra = new Publisher() { Id = 4, Name = "Alexandrakiadó", Headquarters = "Debrecen", Income = 80000000 };

            Author dan = new Author() { Id = 1, Name = "Dan Brown", YearOfBirth = 1964, PlaceOfBirth = "New Hampshire", PublisherId = 1 };
            Author janka = new Author() { Id = 2, Name = "Fábián Janka", YearOfBirth = 1973, PlaceOfBirth = "Budapest", PublisherId = 3 };
            Author eva = new Author() { Id = 3, Name = "Fejős Éva", YearOfBirth = 1967, PlaceOfBirth = "Budapest", PublisherId = 2 };
            Author tamas = new Author() { Id = 4, Name = "Frei Tamás", YearOfBirth = 1966, PlaceOfBirth = "Pécs", PublisherId = 4 };
            Author milan = new Author() { Id = 5, Name = "Ceaser Milan", YearOfBirth = 1969, PlaceOfBirth = "Culiacán", PublisherId = 1 };

            Book lotti = new Book() { Id = 1, Name = "Lotti öröksége", Price = 3399, Length = 121, PublisherId = 3 };
            Book rose = new Book() { Id = 2, Name = "Rose regénye", Price = 5949, Length = 143, PublisherId = 3 };
            Book eredet = new Book() { Id = 3, Name = "Eredet", Price = 4490, Length = 320, PublisherId = 1 };
            Book inferno = new Book() { Id = 4, Name = "Inferno", Price = 3990, Length = 259, PublisherId = 1 };
            Book halal = new Book() { Id = 5, Name = "Halál emlékül", Price = 2990, Length = 108, PublisherId = 2 };
            Book orokre = new Book() { Id = 6, Name = "Örökre Görögbe", Price = 2990, Length = 140, PublisherId = 2 };
            Book babel = new Book() { Id = 7, Name = "Babel", Price = 5990, Length = 231, PublisherId = 4 };
            Book agrar = new Book() { Id = 8, Name = "Agrárbárók", Price = 2999, Length = 199, PublisherId = 4 };
            Book amit = new Book() { Id = 9, Name = "Amit a falkától tanultam", Price = 3790, Length = 201, PublisherId = 1 };

            mb.Entity<Publisher>().HasData(gabo, era, libri, alexandra);
            mb.Entity<Author>().HasData(dan, janka, eva, tamas, milan);
            mb.Entity<Book>().HasData(lotti, rose, eredet, inferno, halal, orokre, babel, agrar, amit);

        }

    }
}
