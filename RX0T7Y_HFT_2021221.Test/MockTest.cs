using Moq;
using RX0T7Y_HFT_2021221.Logic;
using RX0T7Y_HFT_2021221.Models;
using RX0T7Y_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RX0T7Y_HFT_2021221.Test
{
    public class MockTest
    {
        PublisherLogic publisherLog;

        public MockTest()
        {
            /*Publisher fakePublisher = new Publisher()
            {
                Name = "Librikiadó",
                Headquarters = "Budapest",
                Income = 41000000
            };*/


            var publishers = new List<Publisher>()
            {
                new Publisher()
                {
                    Name = "Librikiadó",
                    Headquarters = "Budapest",
                    Income = 41000000
                },
                new Publisher()
                {
                    Name = "Alexandrakiadó",
                    Headquarters = "Debrecen",
                    Income = 800000000
                }
            }.AsQueryable();
            var authors = new List<Author>()
            {
                new Author()
                {
                    Name = "Fábián Janka",
                    YearOfBirth = 1973,
                    PlaceOfBirth = "Budapest",
                    Publisher = publishers.First()
                },
                new Author()
                {
                    Name = "Frei Tamás",
                    YearOfBirth = 1966,
                    PlaceOfBirth = "Pécs",
                    Publisher = publishers.Last()
                }
            }.AsQueryable();
            var books = new List<Book>()
            {
                new Book()
                {
                    Name = "Lotti öröksége",
                    Price = 3399,
                    Length = 121,
                    Publisher = publishers.First()
                },
                new Book()
                {
                    Name = "Rose regénye",
                    Price = 5949,
                    Length = 143,
                    Publisher = publishers.First()
                },
                new Book()
                {
                    Name = "Babel",
                    Price = 5990,
                    Length = 231,
                    Publisher = publishers.Last()
                },
                new Book()
                {
                    Name = "Agrárbárók",
                    Price = 2999,
                    Length = 199,
                    Publisher = publishers.Last()
                }
            }.AsQueryable();

            var mockPublisherRepo = new Mock<IPublisherRepository>();

            mockPublisherRepo.Setup((t) => t.ReadAll()).Returns(publishers);

            publisherLog = new PublisherLogic(mockPublisherRepo.Object);
        }
    }
}
