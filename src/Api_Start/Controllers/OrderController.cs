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
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        IDatabaseInterface db = new Database();
        // GET: api/Order
        //[HttpGet]
        ////public OrderList Get()
        ////{//
        ////    OrderList allOrders = new OrderList()
        ////    //{
        ////    //    Tickets =
        ////    //    TicketsToTransactions = 
        ////    //    TicketTransactions = 
        ////    //}
        ////    return allOrders;
        ////}

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
        //[HttpPost]
        //public IActionResult Post([FromBody] Order value)
        //{
        //    try {


        //    }
        //    catch { }

        //}
        
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
