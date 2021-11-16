using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RX0T7Y_HFT_2021221.Logic;
using RX0T7Y_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RX0T7Y_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBookLogic bl;
        IPublisherLogic pl;
        IAuthorLogic al;

        public StatController(IBookLogic bl, IPublisherLogic pl, IAuthorLogic al)
        {
            this.bl = bl;
            this.pl = pl;
            this.al = al;
        }

        //stat/avgprice
        [HttpGet]
        public double AVGPrice()
        {
            return bl.AvgIncome();
        }

        //stat/GroupByAVGLength
        [HttpGet]
        public IEnumerable<object> GroupByAVGLength()
        {
            return bl.GroupByAVGLength();
        }

        //stat/GroupByPublishers
        [HttpGet]
        public IEnumerable<object> GroupByPublishers()
        {
            return bl.GroupByPublishers();
        }

        //stat/GroupbyPublisher
        [HttpGet]
        public IEnumerable<object> GroupbyPublisher()
        {
            return al.GroupbyPublisher();
        }

        //stat/GroupbyHeadquarters
        [HttpGet]
        public IEnumerable<object> GroupbyHeadquarters()
        {
            return al.GroupbyHeadquarters();
        }

        //stat/AVGPrice
        [HttpGet]
        public double AuthAVGPrice()
        {
            return al.AVGPrice();
        }

        //stat/MaxLength
        [HttpGet]
        public object MaxLength()
        {
            return pl.MaxLength();
        }

        //stat/TheYoungestAuthor
        [HttpGet]
        public object TheYoungestAuthor()
        {
            return pl.TheYoungestAuthor();
        }

        //stat/PublishersBookCount
        [HttpGet]
        public IEnumerable<object> PublishersBookCount()
        {
            return pl.PublishersBookCount();
        }

    }
}
