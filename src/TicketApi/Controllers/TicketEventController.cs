using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicketSystem.DatabaseRepository;
using TicketSystem.DatabaseRepository.Model;

namespace TicketApi.Controllers
{
    [Produces("application/json")]
    [Route("api/TicketEvent")]
    public class TicketEventController : Controller
    {
       private IDatabaseInterface Event = new Database();
        // GET: api/Ticket
        [HttpGet]
        public List<TicketEvent> Get()
        {
            return Event.FindEvent();
        }


        // GET: api/Ticket/5
        [HttpGet("{Search}", Name = "GetEvents")]
        public List<TicketEvent> GetEvents(string Search)
        {
            return Event.FindEvent(Search);
        }

        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody]TicketEvent value)
        {
            Event.EventAdd(value.EventName,value.EventHtmlDescription);

        }
        
        // PUT: api/Ticket/5
        [HttpPut]
        public void Put(int id, [FromBody]TicketEvent a)
        {
            Event.EventUpdate(a); 
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteEvent")]
        public void DeleteEvent(string id)
        {
            Event.EventDelete(id);
                
        }
    }
}
