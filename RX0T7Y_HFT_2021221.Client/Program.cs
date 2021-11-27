using CarDB.Client;
using RX0T7Y_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace RX0T7Y_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(10000);
            RestService rest = new RestService("http://localhost:31278");

            var publishers = rest.Get<Publisher>("publisher");
            var books = rest.Get<Book>("book");
            var authors = rest.Get<Author>("author");

            try
            {
                Menu(rest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        static public void Menu(RestService rest)
        {
            bool end = false;

            while (end == false)
            {
                Console.WriteLine("*********MENU*********");
                Console.WriteLine("(1) option - CRUDS");
                Console.WriteLine("(2) option - NON-CRUDS");
                Console.WriteLine("(0) option - QUIT ");
                Console.WriteLine("**********************");

                int input1 = int.Parse(Console.ReadLine());
                
                Console.Clear();
                
                Console.WriteLine("*********MENU*********");
                Console.WriteLine("(1) option - BOOK");
                Console.WriteLine("(2) option - AUTHOR");
                Console.WriteLine("(3) option - PUBLISHER");
                Console.WriteLine("(0) option - QUIT ");
                Console.WriteLine("**********************");

                int input2 = int.Parse(Console.ReadLine());

                Console.Clear();

                if (input1 == 1)
                {
                    Console.WriteLine("********CRUDS*********");
                    if (input2==1)
                    {
                        Console.WriteLine("********BOOKS*********");
                        Console.WriteLine("*********MENU*********");
                        Console.WriteLine("(1) option - CREATE");
                        Console.WriteLine("(2) option - READ");
                        Console.WriteLine("(3) option - READALL");
                        Console.WriteLine("(4) option - UPDATE");
                        Console.WriteLine("(5) option - DELETE");
                        Console.WriteLine("**********************");

                        string para = Console.ReadLine();
                        Console.Clear();

                        switch (para)
                        {
                            case "1":
                                var book = new Book();

                                Console.WriteLine("Name:");
                                string name = Console.ReadLine();
                                book.Name = name;

                                Console.WriteLine("Price:");
                                int price = int.Parse(Console.ReadLine());
                                book.Price = price;

                                Console.WriteLine("Length:");
                                int length = int.Parse(Console.ReadLine());
                                book.Length = length;

                                Console.WriteLine("PublisherId:");
                                int pubid = int.Parse(Console.ReadLine());
                                book.PublisherId = pubid;
                                
                                rest.Post<Book>(book, "book");
                                
                                break;
                            case "2":
                                
                                int id = int.Parse(Console.ReadLine());
                                var b = rest.Get<Book>(id, "book");

                                Console.WriteLine(b.Name + "\n" + b.Price +"\n"+ b.Length);

                                Console.WriteLine("Push enter to continue");
                                Console.ReadKey();

                                break;
                            case "3":

                                var bs = rest.Get<Book>("book");

                                foreach (var item in bs)
                                {
                                    Console.WriteLine(item.Name + "\n" + item.Price + "\n" + item.Length);
                                    Console.WriteLine();
                                }

                                Console.WriteLine("Push enter to continue");
                                Console.ReadKey();

                                break;
                            case "4":
                                var newBook = new Book();

                                name = Console.ReadLine();
                                newBook.Name = name;

                                Console.WriteLine("Price:");
                                price = int.Parse(Console.ReadLine());
                                newBook.Price = price;

                                Console.WriteLine("Length:");
                                length = int.Parse(Console.ReadLine());
                                newBook.Length = length;

                                Console.WriteLine("PublisherId:");
                                pubid = int.Parse(Console.ReadLine());
                                newBook.PublisherId = pubid;

                                rest.Put<Book>(newBook, "book");
                                
                                break;
                            case "5":
                                id = int.Parse(Console.ReadLine());

                                rest.Delete(id, "book");
                                break;
                        }
                    }
                    else if (input2 == 2)
                    {
                        Console.WriteLine("********AUTHORS*******");
                        Console.WriteLine("*********MENU*********");
                        Console.WriteLine("(1) option - CREATE");
                        Console.WriteLine("(2) option - READ");
                        Console.WriteLine("(3) option - READALL");
                        Console.WriteLine("(4) option - UPDATE");
                        Console.WriteLine("(5) option - DELETE");
                        Console.WriteLine("**********************");

                        string para = Console.ReadLine();
                        Console.Clear();

                        switch (para)
                        {
                            case "1":
                                var author = new Author();

                                Console.WriteLine("Name:");
                                string name = Console.ReadLine();
                                author.Name = name;

                                Console.WriteLine("Year of birth:");
                                int yob = int.Parse(Console.ReadLine());
                                author.YearOfBirth = yob;

                                Console.WriteLine("Place of birth:");
                                string pob = Console.ReadLine();
                                author.PlaceOfBirth = pob;

                                Console.WriteLine("PublisherId:");
                                int pubid = int.Parse(Console.ReadLine());
                                author.PublisherId = pubid;

                                rest.Post<Author>(author, "author");
                                
                                break;
                            case "2":

                                int id = int.Parse(Console.ReadLine());
                                var a = rest.Get<Author>(id, "author");

                                Console.WriteLine(a.Name + "\n" + a.YearOfBirth + "\n" + a.PlaceOfBirth);

                                Console.WriteLine("Push enter to continue");
                                Console.ReadKey();

                                break;
                            case "3":

                                var aus = rest.Get<Author>("author");

                                foreach (var item in aus)
                                {
                                    Console.WriteLine(item.Name + "\n" + item.YearOfBirth + "\n" + item.PlaceOfBirth);
                                    Console.WriteLine();
                                }

                                Console.WriteLine("Push enter to continue");
                                Console.ReadKey();

                                break;
                            case "4":
                                var newAuthor = new Author();

                                Console.WriteLine("Name:");
                                name = Console.ReadLine();
                                newAuthor.Name = name;

                                Console.WriteLine("Year of birth:");
                                yob = int.Parse(Console.ReadLine());
                                newAuthor.YearOfBirth = yob;

                                Console.WriteLine("Place of birth:");
                                pob = Console.ReadLine();
                                newAuthor.PlaceOfBirth = pob;

                                Console.WriteLine("PublisherId:");
                                pubid = int.Parse(Console.ReadLine());
                                newAuthor.PublisherId = pubid;

                                rest.Put<Author>(newAuthor, "author");
                                
                                break;
                            case "5":
                                id = int.Parse(Console.ReadLine());

                                rest.Delete(id, "book");
                                break;
                        }
                    }
                    else if (input2==3)
                    {
                        Console.WriteLine("******PUBLISHERS******");
                        Console.WriteLine("*********MENU*********");
                        Console.WriteLine("(1) option - CREATE");
                        Console.WriteLine("(2) option - READ");
                        Console.WriteLine("(3) option - READALL");
                        Console.WriteLine("(4) option - UPDATE");
                        Console.WriteLine("(5) option - DELETE");
                        Console.WriteLine("**********************");

                        string para = Console.ReadLine();
                        Console.Clear();

                        switch (para)
                        {
                            case "1":
                                var publisher = new Publisher();

                                Console.WriteLine("Name:");
                                string name = Console.ReadLine();
                                publisher.Name = name;

                                Console.WriteLine("Income:");
                                int income = int.Parse(Console.ReadLine());
                                publisher.Income = income;

                                Console.WriteLine("Headquarters:");
                                string head = Console.ReadLine();
                                publisher.Headquarters = head;

                                rest.Post<Publisher>(publisher, "publisher");

                                break;
                            case "2":

                                int id = int.Parse(Console.ReadLine());
                                var p = rest.Get<Publisher>(id, "publisher");

                                Console.WriteLine("Push enter to continue");
                                Console.ReadKey();

                                break;
                            case "3":

                                var bs = rest.Get<Publisher>("publisher");

                                foreach (var item in bs)
                                {
                                    Console.WriteLine(item.Name + "\n" + item.Headquarters + "\n" + item.Income);
                                    Console.WriteLine();
                                }

                                Console.WriteLine("Push enter to continue");
                                Console.ReadKey();

                                break;
                            case "4":
                                var newPublisher = new Publisher();

                                Console.WriteLine("Name:");
                                name = Console.ReadLine();
                                newPublisher.Name = name;

                                Console.WriteLine("Income:");
                                income = int.Parse(Console.ReadLine());
                                newPublisher.Income = income;

                                Console.WriteLine("Headquarters:");
                                head = Console.ReadLine();
                                newPublisher.Headquarters = head;

                                rest.Put<Publisher>(newPublisher, "publisher");

                                break;
                            case "5":
                                id = int.Parse(Console.ReadLine());

                                rest.Delete(id, "publisher");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("INCORRECT INPUT");
                    }
                }
                else if (input1 == 2)
                {
                    Console.WriteLine("******NON-CRUDS******");
                    if (input2 == 1)
                    {
                        Console.WriteLine("********BOOKS********");

                        Console.WriteLine("*********METHODS*********");
                        Console.WriteLine("(1) option - AvgPrice");
                        Console.WriteLine("(2) option - GroupByAvgLength");
                        Console.WriteLine("(3) option - GroupByPublishers");
                        Console.WriteLine("**********************");

                        int input3 = int.Parse(Console.ReadLine());
                        Console.Clear();

                        switch (input3)
                        {
                            case 1:

                                var q1 = rest.GetSingle<double>("stat/AVGPrice");
                                Console.WriteLine(q1);

                                break;
                            case 2:

                                var q2 = rest.GetSingle<IEnumerable<object>>("stat/GroupByAVGLength");
                                foreach (var item in q2)
                                {
                                    Console.WriteLine(item);
                                }

                                break;
                            case 3:

                                var q3 = rest.GetSingle<IEnumerable<object>>("stat/GroupByPublishers");
                                foreach (var item in q3)
                                {
                                    Console.WriteLine(item);
                                }

                                break;
                        }
                    }
                    else if (input2 == 2)
                    {
                        Console.WriteLine("*****AUTHORS*****");

                        Console.WriteLine("*********METHODS*********");
                        Console.WriteLine("(1) option - GroupbyPublisher");
                        Console.WriteLine("(2) option - GroupbyHeadquarters");
                        Console.WriteLine("(3) option - AuthAVGPrice");
                        Console.WriteLine("**********************");

                        int input3 = int.Parse(Console.ReadLine());
                        Console.Clear();

                        switch (input3)
                        {
                            case 1:

                                var q1 = rest.GetSingle<IEnumerable<object>>("stat/GroupbyPublisher");
                                foreach (var item in q1)
                                {
                                    Console.WriteLine(item);
                                }

                                break;
                            case 2:

                                var q2 = rest.GetSingle<IEnumerable<object>>("stat/GroupbyHeadquarters");
                                foreach (var item in q2)
                                {
                                    Console.WriteLine(item);
                                }

                                break;
                            case 3:

                                var q3 = rest.GetSingle<double>("stat/AVGPrice");
                                Console.WriteLine(q3);

                                break;
                        }
                    }
                    else if (input2 == 3)
                    {
                        Console.WriteLine("*****PUBLISHERS*****");

                        Console.WriteLine("*********METHODS*********");
                        Console.WriteLine("(1) option - MaxLength");
                        Console.WriteLine("(2) option - TheYoungestAuthor");
                        Console.WriteLine("(3) option - PublishersBookCount");
                        Console.WriteLine("**********************");

                        int input3 = int.Parse(Console.ReadLine());
                        Console.Clear();

                        switch (input3)
                        {
                            case 1:

                                var q1 = rest.GetSingle<object>("stat/MaxLength");
                                Console.WriteLine(q1);

                                break;
                            case 2:

                                var q2 = rest.GetSingle<object>("stat/TheYoungestAuthor");
                                Console.WriteLine(q2);

                                break;
                            case 3:

                                var q3 = rest.GetSingle<IEnumerable<object>>("/stat/PublishersBookCount");
                                foreach (var item in q3)
                                {
                                    Console.WriteLine(item);
                                }

                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("INCORRECT INPUT");
                    }
                }
                else if (input1 == 0 && input2 == 0)
                {
                    end = true;
                    Console.WriteLine("QUIT CONFIRMED");
                }
                else
                {
                    Console.WriteLine("INCORRECT INPUT");
                }
            }
            
        }
    }
}
