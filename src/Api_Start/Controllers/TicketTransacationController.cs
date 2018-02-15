using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;
using TicketSystem.DatabaseRepository.Model;

namespace Api_Start.Controllers
{
    [Produces("application/json")]
    [Route("api/TicketTransacation")]
    public class TicketTransacationController : Controller
    {
        IDatabaseInterface DataBaseHandler = new Database();
        // GET: api/TicketTransacation
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TicketTransacation/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/TicketTransacation
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/TicketTransacation/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
