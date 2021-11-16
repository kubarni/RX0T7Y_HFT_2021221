using RX0T7Y_HFT_2021221.Models;
using RX0T7Y_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RX0T7Y_HFT_2021221.Logic
{
    public class BookLogic
    {
        IBookRepository bookRepo;

        public BookLogic(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        //CRUD methods

        public void Create(Book book)
        {
            if (book.Length <= 0)
            {
                throw new ArgumentException("Negative length is not allowed!!");
            }
            bookRepo.Create(book);
        }

        public Book Read(int id)
        {
            if (id >=0 )
            {
                return bookRepo.Read(id);
            }
            else
            {
                throw new ArgumentException("Impossible data");
            }
        }

        public IEnumerable<Book> ReadAll()
        {
            return bookRepo.ReadAll();
        }

        public void Delete(int id)
        {
            bookRepo.Delete(id);
        }

        public void Update(Book book)
        {
            bookRepo.Update(book);
        }

        //-----------------

        public double AvgIncome()
        {
            var q = bookRepo.ReadAll().Average(t => t.Publisher.Income);

            return q;
        }

        public IEnumerable<object> GroupByPublishers()
        {
            var q = from x in bookRepo.ReadAll()
                    group x by x.Publisher.Name into g
                    select new
                    {
                        Name = g.Key,
                        AvgPrice = g.Average(k => k.Price)
                    };

            return q;
        }

        public IEnumerable<object> GroupByAVGLength()
        {
            var q = from x in bookRepo.ReadAll()
                    group x by x.Publisher.Id into g
                    select new
                    {
                        PublisherId = g.Key,
                        AvgPrice = g.Average(k => k.Length)
                    };

            return q;
        }


    }
}
