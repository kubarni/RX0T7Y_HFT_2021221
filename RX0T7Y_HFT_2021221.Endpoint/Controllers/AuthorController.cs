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
    public class AuthorController : ControllerBase
    {
        IHubContext<SignalRHub> hub;
        IAuthorLogic al;

        public AuthorController(IAuthorLogic al, IHubContext<SignalRHub> hub)
        {
            this.al = al;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return al.ReadAll();
        }

        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return al.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Author value)
        {
            al.Create(value);
            this.hub.Clients.All.SendAsync("AuthorCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Author value)
        {
            al.Update(value);
            this.hub.Clients.All.SendAsync("AuthorUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var authorToDelete = this.al.Read(id);
            al.Delete(id);
            this.hub.Clients.All.SendAsync("AuthorDeleted", authorToDelete);
        }
    }
}
