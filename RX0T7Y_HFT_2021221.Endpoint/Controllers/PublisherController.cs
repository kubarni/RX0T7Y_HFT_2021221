using Microsoft.AspNetCore.Mvc;
using RX0T7Y_HFT_2021221.Logic;
using RX0T7Y_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RX0T7Y_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {

        IPublisherLogic pl;

        public PublisherController(IPublisherLogic pl)
        {
            this.pl = pl;
        }

        [HttpGet]
        public IEnumerable<Publisher> Get()
        {
            return pl.ReadAll();
        }

        [HttpGet("{id}")]
        public Publisher Get(int id)
        {
            return pl.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Publisher value)
        {
            pl.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Publisher value)
        {
            pl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }

    }
}
