using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;
using TicketSystem.DatabaseRepository.Model;

namespace TicketApi.Controllers
{
    [Produces("application/json")]
    [Route("api/TicketEvent")]
    public class TicketEventController : Controller
    {
        ITicketDatabase test = new TicketDatabase();
        // GET: api/Ticket
        [HttpGet]
        public List<TicketEvent> Get()
        {
            return test.AllEvents();
        }


        // GET: api/Ticket/5
        [HttpGet("{Search}", Name = "Get")]
        public List<TicketEvent> GetVenues(string Search)
        {
            return test.EventsFind(Search);
        }

        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody]TicketEvent value)
        {
            test.AllEvents();

        }
        
        // PUT: api/Ticket/5
        [HttpPut]
        public void Put(int id, [FromBody]TicketEvent a)
        {
            test.EventUpdate(a); 
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "Delete")]
        public void Delete(string id)
        {
            test.EventDelete(id);
                
        }
    }
}
