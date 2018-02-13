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

//        private IDatabaseInterface TicketEventDate = new Database();
//        // GET: api/TicketEventDate
//        [HttpGet]
//        public IEnumerable<TicketEventDate> Get()

//        {
//            return TicketEventDate.FindTicketEventDate();
//        }

//        //GET: api/TicketEventDate/5

//        [HttpGet("{Search}", Name = "GetTicketEventDates")]
//        public List<TicketEventDate> GetTicketEventDates(string Search)
//        {
//            return TicketEventDate.FindTicketEventDate(Search);

//        }

//        // POST: api/TicketEventDate
//        [HttpPost]
//        public void Post([FromBody]TicketEventDate value)
//        {
//            TicketEventDate.TicketEventDateAdd(value.TicketEventDateID, value.TicketEventID, value.VenueId, value.EventStartDateTime);
                
//          }

//        // PUT: api/TicketEventDate/5
//        [HttpPut("{id}")]


//        public void Put(int id, [FromBody]TicketEventDate value)
//        {
//            TicketEventDate.TicketEventDateDelete();
//        }

//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{id}", Name = "DeleteTicketEventDate")]
//        public void DeleteTicketEventDate(int id)
//        {
//            TicketEventDate.TicketEventDateDelete(id);
//        }
   }
}
