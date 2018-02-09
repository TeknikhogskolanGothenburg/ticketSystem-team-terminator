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
    [Route("api/Venues")]
    public class VenuesController : Controller
    {
        ITicketDatabase test = new TicketDatabase();
        // GET: api/Ticket
        [HttpGet]
        public IEnumerable<Venue> Get()
        {
            // GET: api/Ticket
            
            return test.VenuesAll();
                
        }

        // GET: api/Ticket/5
        [HttpGet("{Search}", Name = "Get")]
        public List<Venue> GetVenues(string Search)
        {
            return test.VenuesFind(Search);
        }
        
        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody]Venue value)
        {
           
            test.VenueAdd(value.VenueName, value.Address, value.City, value.Country);
        }
        
        // PUT: api/Ticket/5
        [HttpPut]
        public void Put( [FromBody]Venue a)
        {
            
            test.VenueUpdate(a);

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "Delete")]
        public void Delete(int id)
        {
           
            test.VenueDelete(id);
        }
    }
}
