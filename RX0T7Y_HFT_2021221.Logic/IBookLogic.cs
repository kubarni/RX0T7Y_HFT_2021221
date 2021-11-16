using RX0T7Y_HFT_2021221.Models;
using System.Collections.Generic;

namespace RX0T7Y_HFT_2021221.Logic
{
    public interface IBookLogic
    {
        double AvgIncome();
        void Create(Book book);
        void Delete(int id);
        IEnumerable<object> GroupByAVGLength();
        IEnumerable<object> GroupByPublishers();
        Book Read(int id);
        IEnumerable<Book> ReadAll();
        void Update(Book book);
    }
}