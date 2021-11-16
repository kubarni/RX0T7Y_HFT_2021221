using CarDB.Client;
using RX0T7Y_HFT_2021221.Models;
using System;

namespace RX0T7Y_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(15000);
            RestService rest = new RestService("http://localhost:31278");

            var publishers = rest.Get<Publisher>("publisher");
            ;
        }
    }
}
