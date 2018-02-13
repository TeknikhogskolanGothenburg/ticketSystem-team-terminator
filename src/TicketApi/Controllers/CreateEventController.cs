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
    [Route("api/CreateEvent")]
    public class CreateEventController : Controller
    {
        private IDatabaseInterface DbHandler = new Database();
        // GET: api/CreateEvent
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CreateEvent/5
        [HttpGet("{id}",Name = "SearhEventype")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/CreateEvent
        [HttpPost]
        public void Post([FromBody]Event value)
        {
            DbHandler.TicketEventDate(DbHandler.EventAdd(value.TicketEvents.EventName, value.TicketEvents.EventHtmlDescription), DbHandler.VenueAdd(value.Venues.VenueName, value.Venues.Address, value.Venues.City, value.Venues.Country), value.TicketEventDates.EventStartDateTime);
            DbHandler.
           

        }
        
        // PUT: api/CreateEvent/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
