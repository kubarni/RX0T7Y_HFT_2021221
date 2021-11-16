using Moq;
using NUnit.Framework;
using RX0T7Y_HFT_2021221.Logic;
using RX0T7Y_HFT_2021221.Models;
using RX0T7Y_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RX0T7Y_HFT_2021221.Test
{
    [TestFixture]
    public class MockTest
    {
        PublisherLogic publisherLog;
        AuthorLogic authorLog;
        BookLogic bookLog;

        public MockTest()
        {

            var publishers = new List<Publisher>()
            {
                new Publisher()
                {
                    Id = 1,
                    Name = "Librikiadó",
                    Headquarters = "Budapest",
                    Income = 41000000
                },
                new Publisher()
                {
                    Id = 2,
                    Name = "Alexandrakiadó",
                    Headquarters = "Debrecen",
                    Income = 800000000
                }
            }.AsQueryable();

            var authors = new List<Author>()
            {
                new Author()
                {
                    Id = 1,
                    Name = "Fábián Janka",
                    YearOfBirth = 1973,
                    PlaceOfBirth = "Budapest",
                    PublisherId = 1,
                    Publisher = publishers.First()
                },
                new Author()
                {
                    Id =2,
                    Name = "Frei Tamás",
                    YearOfBirth = 1966,
                    PlaceOfBirth = "Pécs",
                    PublisherId = 2,
                    Publisher = publishers.Last()
                }
            }.AsQueryable();


            var books = new List<Book>()
            {
                new Book()
                {
                    Id=1,
                    Name = "Lotti öröksége",
                    Price = 3399,
                    Length = 121,
                    PublisherId = 1,
                    Publisher = publishers.First()
                },
                new Book()
                {
                    Id=2,
                    Name = "Rose regénye",
                    Price = 5949,
                    Length = 143,
                    PublisherId = 1,
                    Publisher = publishers.First()
                },
                new Book()
                {
                    Id=3,
                    Name = "Babel",
                    Price = 5990,
                    Length = 231,
                    PublisherId = 2,
                    Publisher = publishers.Last()
                },
                new Book()
                {
                    Id=4,
                    Name = "Agrárbárók",
                    Price = 2999,
                    Length = 199,
                    PublisherId = 2,
                    Publisher = publishers.Last()
                }
            }.AsQueryable();

            var mockPublisherRepo = new Mock<IPublisherRepository>();
            var mockAuthorRepo = new Mock<IAuthorRepository>();
            var mockBookRepo = new Mock<IBookRepository>();

            mockPublisherRepo.Setup((t) => t.ReadAll()).Returns(publishers);
            mockAuthorRepo.Setup((t) => t.ReadAll()).Returns(authors);
            mockBookRepo.Setup((t) => t.ReadAll()).Returns(books);

            publisherLog = new PublisherLogic(mockPublisherRepo.Object);
            authorLog = new AuthorLogic(mockAuthorRepo.Object);
            bookLog = new BookLogic(mockBookRepo.Object);

        }

        [Test]
        public void authGroupbyPublisherTest()
        {
            var result = authorLog.GroupbyPublisher();

            Assert.That(result.Count() == 2);
        }

        [Test]
        public void AVGIncomeTest()
        {
            var result = bookLog.AvgIncome();

            Assert.That(result, Is.EqualTo(420500000));
        }

        /*[Test]
        public void AVGPrice()
        {
            var result = authorLog.AVGPrice();

            Assert.That(result, Is.EqualTo(4584.25));
        }*/

        [Test]
        public void GroupbyHeadquartersTest()
        {
            var result = authorLog.GroupbyHeadquarters();

            Assert.That(result.Count() == 2);
        }

        [TestCase(true, 200, 5000)]
        [TestCase(false, -5, -5000)]
        public void BookCreateTest(bool result, int length, int price)
        {
            if (result)
            {
                Assert.That(() => bookLog.Create(new Book()
                {
                    Name = "Próba",
                    Length = length,
                    Price = price
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => bookLog.Create(new Book()
                {
                    Name = "Próba",
                    Length = length,
                    Price = price
                }), Throws.Exception);
            }
        }

        [TestCase(true, 12)]
        [TestCase(false, -5)]
        public void BookReadTest(bool result, int id)
        {
            if (result && id >= 0)
            {
                Assert.That(() => bookLog.Read(id), Throws.Nothing);
            }
            else
            {
                Assert.That(() => bookLog.Read(id), Throws.Exception);
            }
        }

        [TestCase(true, 2)]
        [TestCase(false, -9)]
        public void AuthorReadTest(bool result, int id)
        {
            if (result && id >= 0)
            {
                Assert.That(() => authorLog.Read(id), Throws.Nothing);
            }
            else
            {
                Assert.That(() => authorLog.Read(id), Throws.Exception);
            }
        }


        [TestCase(false, -2000)]
        [TestCase(true, 1999)]
        public void AuthorCreateTest(bool result, int dob)
        {
            if (result && dob >= 0)
            {
                Assert.That(() => authorLog.Create(new Author()
                {
                    Name = "Próba",
                    PlaceOfBirth = "Bp",
                    YearOfBirth = dob
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => authorLog.Create(new Author()
                {
                    Name = "Próba",
                    PlaceOfBirth = "Bp",
                    YearOfBirth = dob
                }), Throws.Exception);
            }
        }

        [Test]
        public void GroupbyAVGPrice()
        {
            var result = bookLog.GroupByPublishers();

            Assert.That(result.Count() == 2);
        }

        [TestCase(false, -40000)]
        [TestCase(true, 40000)]
        public void PublisherCreateCheck(bool result, int income)
        {
            if (result)
            {
                Assert.That(() => publisherLog.Create(new Publisher()
                {
                    Name = "Próba",
                    Headquarters = "Bp",
                    Income = income
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => publisherLog.Create(new Publisher()
                {
                    Name = "Próba",
                    Headquarters = "Bp",
                    Income = income
                }), Throws.Exception);
            }
        }

        [Test]
        public void bookGroupbyPublisherTest()
        {
            var result = bookLog.GroupByPublishers();

            Assert.That(result.Count() == 2);
        }
    }
}
