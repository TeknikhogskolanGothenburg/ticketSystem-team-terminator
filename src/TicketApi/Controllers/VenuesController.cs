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
        // GET: api/Venues
        [HttpGet]
        public IEnumerable<Venue> Get()
        {
            return Venue.FindVenue();                
        }

        // GET: api/Venues/Search
        [HttpGet("{Search}", Name = "GetVenues")]
        public List<Venue> GetVenues(string Search)
        {
            return Venue.FindVenue(Search);
        }

        // POST: api/Venues
        [HttpPost]
        public void Post([FromBody]Venue value)
        {
           
            Venue.VenueAdd(value.VenueName, value.Address, value.City, value.Country);
        }

        // PUT: api/Venues
        [HttpPut("{id}")]
        public void Put( int id, [FromBody]Venue a)
        { 
                Venue.VenueUpdate(id, a.VenueName, a.Address, a.City, a.Country);
        }

        // DELETE: api/Venues/5
        [HttpDelete("{id}", Name = "DeleteVenues")]
        public void DeleteVenues(int id)
        {
           
            Venue.VenueDelete(id);
        }
    }
}
