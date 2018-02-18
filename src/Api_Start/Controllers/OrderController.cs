﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;
using TicketSystem.DatabaseRepository.Model;
using System.Linq;

namespace Api_Start.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        IDatabaseInterface db = new Database();
        //visar en lista av event som går att boka , visar ej gamla event
        //GET: api/Order
       [HttpGet]
       public List<EventTest> Get()
        {
            List<EventTest> e = new List<EventTest>();
            e.Add(new EventTest()
            {
                EventStartDateTime = DateTime.Now,
            });
              
       
            return db.GetallEventsAvadible().Where( x => x.EventStartDateTime >= e[0].EventStartDateTime).ToList();
        }

        //// GET: api/Order/5
        //[HttpGet("{id}", Name = "GetTickets")]
        ////public string GetTickets(int id)
        ////{
        ////    OrderList orders = new OrderList()
        ////    {
        ////        Tickets =
        ////        TicketsToTransactions =
        ////        TicketTransactions =
        ////    }
        ////}

       // POST: api/Order
       [HttpPost]
        public IActionResult Post([FromBody] Order value)
        {
            try
            {
              

            }
            catch {
                return StatusCode(500);

            }
            return Ok();
        }


        // PUT: api/Order/5
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
