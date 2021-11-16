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
    public class BookController : ControllerBase
    {

        IBookLogic bl;

        public BookController(IBookLogic bl)
        {
            this.bl = bl;
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
        }

        [HttpPut]
        public void Put([FromBody] Book value)
        {
            bl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.Delete(id);
        }
    }
}
