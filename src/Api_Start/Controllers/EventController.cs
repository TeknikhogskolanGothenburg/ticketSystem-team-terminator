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
    [Route("api/Event")]
    public class EventController : Controller
    {
        IDatabaseInterface DbHandler = new Database();
        // GET: api/CEvent
        [HttpGet]
        public List<EventTest> Get()
        {

                return DbHandler.GetallEventsAvadible();
           
           
        }

        // GET: api/CreateEvent/5
        //[HttpGet("{Search}", Name = "SearchEVent")]
        //public EventList Get(string Search)
        //{
        //    /// bara ett test fungerar ej
        //    EventList Events = new EventList()
        //    {
        //        TicketEvents = DbHandler.FindEvent(Search),
        //        Venues = DbHandler.FindVenue(Search),
        //        TicketEventDates = DbHandler.FindTicketEventDate(Search)
        //    };
        //    return Events;
        //}
        //
        // POST: api/CreateEvent
        [HttpPost]
        public void Post([FromBody]Event value)
        {
            try
            {
                int VenueId = DbHandler.VenueAdd(value.Venues.VenueName, value.Venues.Address, value.Venues.City, value.Venues.Country);
                int eventID = DbHandler.EventAdd(value.TicketEvents.EventName, value.TicketEvents.EventHtmlDescription);
                int TicketeventdateID = DbHandler.TicketEventDate(eventID, VenueId, value.TicketEventDates.EventStartDateTime);
                for (int i = 0; i < value.Seats; i++)
                {
                    DbHandler.SeatsAtEventDateAdd(TicketeventdateID);
                }

            }
            catch
            {
               
            }
        }
        
        // PUT: api/CreateEvent/5
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
