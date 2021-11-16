using RX0T7Y_HFT_2021221.Models;
using System.Collections.Generic;

namespace RX0T7Y_HFT_2021221.Logic
{
    public interface IPublisherLogic
    {
        void Create(Publisher publisher);
        void Delete(int id);
        object MaxLength();
        IEnumerable<object> PublishersBookCount();
        Publisher Read(int id);
        IEnumerable<Publisher> ReadAll();
        object TheYoungestAuthor();
        void Update(Publisher publisher);
    }
}