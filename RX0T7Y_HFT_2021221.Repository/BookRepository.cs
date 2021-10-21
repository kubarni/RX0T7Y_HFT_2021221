using RX0T7Y_HFT_2021221.Data;
using RX0T7Y_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RX0T7Y_HFT_2021221.Repository
{
    public class BookRepository : IBookRepository
    {
        BookAuthorPublisherDbContext db;

        public BookRepository(BookAuthorPublisherDbContext db)
        {
            this.db = db;
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public Book Read(int id)
        {
            return db.Books.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Book> ReadAll()
        {
            return db.Books;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Book book)
        {
            var oldbook = Read(book.Id);
            oldbook.Name = book.Name;
            oldbook.Length = book.Length;
            oldbook.Price = book.Price;
            oldbook.PublisherId = book.PublisherId;

            db.SaveChanges();
        }
    }
}
