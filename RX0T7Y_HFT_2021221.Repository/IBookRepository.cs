﻿using RX0T7Y_HFT_2021221.Models;
using System.Linq;

namespace RX0T7Y_HFT_2021221.Repository
{
    public interface IBookRepository
    {
        void Create(Book book);
        void Delete(int id);
        Book Read(int id);
        IQueryable<Book> ReadAll();
        void Update(Book book);
    }
}