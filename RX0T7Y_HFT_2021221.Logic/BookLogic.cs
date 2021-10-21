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
            if(book.Length <= 0)
            {
                throw new ArgumentException("Negative length is not allowed!!");
            }
            bookRepo.Create(book);
        }

        public Book Read(int id)
        {
            return bookRepo.Read(id);
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

        //Non-CRUD methods

        public double AVGPrice()
        {
            return bookRepo.ReadAll().Average(t => t.Price);
        }

        public double AVGLength()
        {
            return bookRepo.ReadAll().Average(t => t.Length);
        }
    }
}
