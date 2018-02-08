﻿using System;
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
    [Route("api/Ticket")]
    public class VenuesController : Controller
    {
        // GET: api/Ticket
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Ticket/5
        [HttpGet("{Search}", Name = "Get")]
        public List<Venue> Get(string Search)
        {
            ITicketDatabase test = new TicketDatabase();


            return test.VenuesFind(Search);

        }
        
        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
