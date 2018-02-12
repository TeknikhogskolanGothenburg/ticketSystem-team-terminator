using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;

namespace TicketApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Ticket")]
    public class TicketController : Controller
    {
        IDatabaseInterface ticket = new Database();
        // GET: api/Ticket
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return ticket.AllTickets();
        }

        // GET: api/Ticket/5
        [HttpGet("{ticketID}", Name = "Get")]
        public List<int> Get(int ticketId)
        {
            return ticket.FindSeatID(ticketId);
        }
        
        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody]int seatID)
        {
            ticket.TicketAdd(seatID);
        }
        
        // PUT: api/Ticket/5
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
