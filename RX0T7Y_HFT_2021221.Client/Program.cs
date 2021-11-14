﻿using RX0T7Y_HFT_2021221.Data;
using RX0T7Y_HFT_2021221.Logic;
using RX0T7Y_HFT_2021221.Repository;
using System;

namespace RX0T7Y_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            BookAuthorPublisherDbContext db = new BookAuthorPublisherDbContext();

            IAuthorRepository authorRepo = new AuthorRepository(db);
            AuthorLogic authorLog = new AuthorLogic(authorRepo);

            IBookRepository bookRepo = new BookRepository(db);
            BookLogic bookLog = new BookLogic(bookRepo);

            IPublisherRepository publisherRepo = new PublisherRepository(db);
            PublisherLogic publisherLog = new PublisherLogic(publisherRepo);

            var q0 = publisherLog.ReadAll();

            var q1 = publisherLog.GroupByPublishers();

            var q2 = publisherLog.AveragePrice();

            var q3 = publisherLog.MaxLength();

            var q4 = publisherLog.TheYoungestAuthor();

            var q5 = publisherLog.PublishersBookCount();

            ;
        }
    }
}
