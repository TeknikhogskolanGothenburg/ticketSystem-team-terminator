﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository.Model;

namespace TicketApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Ticket")]
    public class TicketEventController : Controller
    {
        // GET: api/Ticket
        [HttpGet]
        //public List<TicketEvent> Get()
        //{
        //    return;
        //}
       ///

        // GET: api/Ticket/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Ticket/5
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