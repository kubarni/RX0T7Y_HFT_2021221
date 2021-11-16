using RX0T7Y_HFT_2021221.Models;
using RX0T7Y_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RX0T7Y_HFT_2021221.Logic
{
    public class PublisherLogic : IPublisherLogic
    {
        IPublisherRepository publisherRepo;

        public PublisherLogic(IPublisherRepository publisherRepo)
        {
            this.publisherRepo = publisherRepo;
        }

        //CRUD methods

        public void Create(Publisher publisher)
        {
            if (publisher.Income < 0)
            {
                throw new ArgumentException("Publisher is broken!");
            }
            publisherRepo.Create(publisher);
        }

        public Publisher Read(int id)
        {
            return publisherRepo.Read(id);
        }

        public IEnumerable<Publisher> ReadAll()
        {
            return publisherRepo.ReadAll();
        }

        public void Delete(int id)
        {
            publisherRepo.Delete(id);
        }

        public void Update(Publisher publisher)
        {
            publisherRepo.Update(publisher);
        }

        //non-CRUD methods

        public object MaxLength()
        {
            var maxL = publisherRepo.ReadAll().SelectMany(t => t.Books).Max(m => m.Length);

            var bookName = (from x in publisherRepo.ReadAll().SelectMany(t => t.Books)
                            where x.Length == maxL
                            select x.Name).ToArray();

            string finisingName = bookName[0];

            object obj = new { finisingName, maxL };

            return obj;
        }

        public object TheYoungestAuthor()
        {
            var youngestYear = publisherRepo.ReadAll().SelectMany(t => t.Authors).Max(m => m.YearOfBirth);

            var Name = (from x in publisherRepo.ReadAll().SelectMany(t => t.Authors)
                        where x.YearOfBirth == youngestYear
                        select x.Name).ToArray();

            string finisingName = Name[0];

            object obj = new { finisingName, youngestYear };

            return obj;
        }

        public IEnumerable<object> PublishersBookCount()
        {
            var q = from x in publisherRepo.ReadAll().SelectMany(t => t.Books)
                    group x by x.PublisherId into g
                    select new
                    {
                        PublisherId = g.Key,
                        CountValue = g.Count()
                    };

            return q;
        }
    }
}
