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
    [Route("api/TicketEventDate")]
    public class TicketEventDateController : Controller
    {
      private  IDatabaseInterface test = new Database();

        //// GET: api/TicketEventDate
        //[HttpGet]
        //public IEnumerable<TicketEventDate> Get()

        //{
        //    return test.TicketEventDateAll();
        //}

        //// GET: api/TicketEventDate/5

        //[HttpGet("{Search}", Name = "Get")]
        //public List<TicketEventDate> GetTicketEventDate(string Search)
        //{
        //    return test.TicketEventDateFind(Search);

        //}

        //// POST: api/TicketEventDate
        //[HttpPost]
        //public void Post([FromBody]TicketEventDate value)
        //{
        //    test.TicketEventDateAdd(value.TicketEventDateID, value.TicketEventID, value.VenueId, value.EventStartDateTime);
                
        //  }
        
        // PUT: api/TicketEventDate/5
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
