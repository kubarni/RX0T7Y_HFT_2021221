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
    public class BookController : ControllerBase
    {

        IBookLogic bl;
        IHubContext<SignalRHub> hub;

        public BookController(IBookLogic bl, IHubContext<SignalRHub> hub)
        {
            this.bl = bl;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bl.ReadAll();
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return bl.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Book value)
        {
            bl.Create(value);
            this.hub.Clients.All.SendAsync("BookCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Book value)
        {
            bl.Update(value);
            this.hub.Clients.All.SendAsync("BookUpdated", value);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var bookToDelete = this.bl.Read(id);
            bl.Delete(id);
            this.hub.Clients.All.SendAsync("BookDeleted", bookToDelete);
        }
    }
}
