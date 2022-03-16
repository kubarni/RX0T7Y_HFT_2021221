using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RX0T7Y_HFT_2021221.Endpoint.Services;
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
        IHubContext<SignalRHub> hub;

        public PublisherController(IPublisherLogic pl, IHubContext<SignalRHub> hub)
        {
            this.pl = pl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("PublisherCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Publisher value)
        {
            pl.Update(value);
            this.hub.Clients.All.SendAsync("PublisherUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var publisherToDelete = this.pl.Read(id);
            pl.Delete(id);
            this.hub.Clients.All.SendAsync("PublisherDeleted", publisherToDelete);
        }
    }
}
