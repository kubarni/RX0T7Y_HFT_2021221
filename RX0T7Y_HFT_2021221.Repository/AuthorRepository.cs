using RX0T7Y_HFT_2021221.Data;
using RX0T7Y_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RX0T7Y_HFT_2021221.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        BookAuthorPublisherDbContext db;

        public AuthorRepository(BookAuthorPublisherDbContext db)
        {
            this.db = db;
        }

        public void Create(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
        }

        public Author Read(int id)
        {
            return db.Authors.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Author> ReadAll()
        {
            return db.Authors;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Author author)
        {
            var oldauthor = Read(author.Id);
            oldauthor.Name = author.Name;
            oldauthor.PlaceOfBirth = author.PlaceOfBirth;
            oldauthor.PublisherId = author.PublisherId;
            oldauthor.YearOfBirth = author.YearOfBirth;

            db.SaveChanges();
        }
    }
}
