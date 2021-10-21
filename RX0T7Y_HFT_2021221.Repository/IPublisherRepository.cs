using RX0T7Y_HFT_2021221.Models;
using System.Linq;

namespace RX0T7Y_HFT_2021221.Repository
{
    interface IPublisherRepository
    {
        void Create(Publisher publisher);
        void Delete(int id);
        Publisher Read(int id);
        IQueryable<Publisher> ReadAll();
        void Update(Publisher publisher);
    }
}