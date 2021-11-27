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
            string end="";

            while (end != "q")
            {
                Console.WriteLine("*********Menu*********");
                Console.WriteLine("(1) option - CRUDS");
                Console.WriteLine("(2) option - NON-CRUDS");
                Console.WriteLine("(q) option - QUIT ");
                Console.WriteLine("**********************");

                int input1 = int.Parse(Console.ReadLine());
                end = input1.ToString();

                Console.WriteLine("*********Menu*********");
                Console.WriteLine("(1) option - BOOK");
                Console.WriteLine("(2) option - AUTHOR");
                Console.WriteLine("(3) option - PUBLISHER ");
                Console.WriteLine("(q) option - QUIT ");
                Console.WriteLine("**********************");

                int input2 = int.Parse(Console.ReadLine());
                end = input2.ToString();

                if (input1 == 1)
                {
                    Console.WriteLine("*****CRUDS*****");
                    if (input2==1)
                    {
                        Console.WriteLine("*****BOOKS*****");
                        
                        string para = Console.ReadLine();
                        var method = rest.Get<Book>(para);
                    }
                    else if (input2 == 2)
                    {
                        Console.WriteLine("*****AUTHORS*****");

                        string para = Console.ReadLine();
                        var method = rest.Get<Book>(para);
                    }
                    else if (input2==3)
                    {
                        Console.WriteLine("*****PUBLISHERS*****");

                        string para = Console.ReadLine();
                        var method = rest.Get<Book>(para);
                    }
                    else
                    {
                        Console.WriteLine("INCORRECT INPUT");
                        Menu(rest);
                    }
                }
                else if (input1 == 2)
                {
                    Console.WriteLine("******NON-CRUDS******");
                    if (input2 == 1)
                    {
                        Console.WriteLine("*****BOOKS*****");

                        string para = Console.ReadLine();
                        var method = rest.Get<Book>(para);
                    }
                    else if (input2 == 2)
                    {
                        Console.WriteLine("*****AUTHORS*****");

                        string para = Console.ReadLine();
                        var method = rest.Get<Book>(para);
                    }
                    else if (input2 == 3)
                    {
                        Console.WriteLine("*****PUBLISHERS*****");

                        string para = Console.ReadLine();
                        var method = rest.Get<Book>(para);
                    }
                    else
                    {
                        Console.WriteLine("INCORRECT INPUT");
                        Menu(rest);
                    }
                }
                else
                {
                    Console.WriteLine("INCORRECT INPUT");
                    Menu(rest);
                }
            }
            
        }
    }
}
