using RX0T7Y_HFT_2021221.Models;
using System.Collections.Generic;

namespace RX0T7Y_HFT_2021221.Logic
{
    public interface IAuthorLogic
    {
        double AVGPrice();
        void Create(Author author);
        void Delete(int id);
        IEnumerable<object> GroupbyHeadquarters();
        IEnumerable<object> GroupbyPublisher();
        Author Read(int id);
        IEnumerable<Author> ReadAll();
        void Update(Author author);
    }
}