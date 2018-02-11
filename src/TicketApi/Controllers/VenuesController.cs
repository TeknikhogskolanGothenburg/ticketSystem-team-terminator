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
       private IDatabaseInterface Venue = new Database();
        // GET: api/Ticket
        [HttpGet]
        public IEnumerable<Venue> Get()
        {
            // GET: api/Ticket
            
            return Venue.FindVenue();
                
        }

        // GET: api/Ticket/5
        [HttpGet("{Search}", Name = "GetVenues")]
        public List<Venue> GetVenues(string Search)
        {
            return Venue.FindVenue(Search);
        }
        
        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody]Venue value)
        {
           
            Venue.VenueAdd(value.VenueName, value.Address, value.City, value.Country);
        }
        
        // PUT: api/Ticket/5
        [HttpPut]
        public void Put( [FromBody]Venue a)
        {
            
            Venue.VenueUpdate(a);

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteVenues")]
        public void DeleteVenues(int id)
        {
           
            Venue.VenueDelete(id);
        }
    }
}
