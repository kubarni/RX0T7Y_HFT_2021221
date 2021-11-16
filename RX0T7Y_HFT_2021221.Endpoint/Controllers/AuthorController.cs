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
    public class AuthorController : ControllerBase
    {

        IAuthorLogic al;

        public AuthorController(IAuthorLogic al)
        {
            this.al = al;
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
        }

        [HttpPut]
        public void Put([FromBody] Author value)
        {
            al.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            al.Delete(id);
        }


    }
}
