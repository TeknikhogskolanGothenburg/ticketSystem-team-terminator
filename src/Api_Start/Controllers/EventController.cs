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

        //GET: api/CreateEvent/5
        [HttpGet("{Search}", Name = "SearchEVent")]
        public List<EventTest> Get(string Search)
        {
           
            return ;
        }

        // POST: api/CreateEvent
        [HttpPost]
        public IActionResult Post([FromBody]Event value)
        {
            try
            {
                DbHandler.CreateEvent(value);
                
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok();
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
