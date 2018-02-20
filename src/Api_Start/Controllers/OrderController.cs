using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;
using TicketSystem.DatabaseRepository.Model;
using TicketSystem.PaymentProvider;
using MailService;

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
       public List<EventForbooking> Get()
        {
            List<EventForbooking> e = new List<EventForbooking>();
            e.Add(new EventForbooking()
            {
                EventStartDateTime = DateTime.Now,
            });
              
       
            return db.GetallEventsAvadible().Where( x => x.EventStartDateTime.Date.Hour >= e[0].EventStartDateTime.Date.Hour && x.IsTaken == 0).ToList();
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

       // POST: api/Order Bokar in sig på en event 
       [HttpPost]
        public IActionResult Post([FromBody] Order value)
        {
            try
            {
                if (db.CheckTicket(value.TicketID))
                {
                    return StatusCode(500);
                }
                IPaymentProvider payment = new PaymentProvider();
               Payment e = payment.Pay(value.amountToPay,value.valuta,value.TicketID.ToString());
                if(e.PaymentStatus == PaymentStatus.PaymentApproved)
                {

                    db.CreateOrder(value, e);
                    MessageTemplateMaker.InfoHeader = "Tack för ditt köp";
                    MessageTemplateMaker.PersonEmail = value.Email;
                    MessageTemplateMaker.VenueAddres = "Working on it";
                    MessageTemplateMaker.TicketID = value.TicketID.ToString();

                    MailHandler mailSender = new MailHandler();
                        mailSender.body = MessageTemplateMaker.template();
                        mailSender.from = "StackCompany@stackmates.se";
                    mailSender.pasword = "ch3UzNlNiiut";
                    mailSender.subject = "Ticket Shop";
                    mailSender.to = value.Email;
                    mailSender.host = "mx1.hostinger.se";
                    mailSender.port = 587;



                    mailSender.SEND();
                    

               
                }
                else
                {
                    return StatusCode(500);
                }

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
