using RX0T7Y_HFT_2021221.Data;
using RX0T7Y_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RX0T7Y_HFT_2021221.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        BookAuthorPublisherDbContext db;

        public PublisherRepository(BookAuthorPublisherDbContext db)
        {
            this.db = db;
        }

        public void Create(Publisher publisher)
        {
            db.Publishers.Add(publisher);
            db.SaveChanges();
        }

        public Publisher Read(int id)
        {
            return db.Publishers.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Publisher> ReadAll()
        {
            return db.Publishers;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Publisher publisher)
        {
            var oldpublisher = Read(publisher.Id);
            oldpublisher.Name = publisher.Name;
            oldpublisher.Income = publisher.Income;
            oldpublisher.Headquarters = publisher.Headquarters;

            db.SaveChanges();
        }
    }
}
