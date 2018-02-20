using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.DatabaseRepository.Model
{
   public class OrderList
    {

        public string BuyerFirstName { get; set; }
        public string BuyerLastName { get; set; }
        public string PaymentReferenceId { get; set; }
        public int TransactionID { get; set; }
        public int TicketID { get; set; }
        public string EventName { get; set; }
        public string EventHtmlDescription { get; set; }
        //public string EventHtmlDescription { get; set; }





        //, P.,P., TOTRAC., TT., TE.,TE.,TED.TicketEventDateID, TED.EventStartDateTime,V.VenueName, V.Address, V.City







    }
}
