using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.DatabaseRepository.Model
{
   public class OrderRefence
    {

        public string BuyerFirstName { get; set; }
        public string BuyerLastName { get; set; }
        public string PaymentReferenceId { get; set; }
        public int TransactionID { get; set; }
        public int TicketID { get; set; }
        public string EventName { get; set; }
        public string EventHtmlDescription { get; set; }
        public int TicketEventDateID { get; set; }
        public DateTime EventStartDateTime { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }





       




    }
}
