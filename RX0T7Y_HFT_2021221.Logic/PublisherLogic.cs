using RX0T7Y_HFT_2021221.Models;
using RX0T7Y_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RX0T7Y_HFT_2021221.Logic
{
    public class PublisherLogic
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

        //Non-CRUD methods soon...
    }
}
