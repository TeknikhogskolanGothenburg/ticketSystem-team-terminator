using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.RestApiClient.Model
{
   public class TicketEvent
    {
        public int TicketEventID { get; set; }
        public string EventName { get; set; }
        public string EventHtmlDescription { get; set; }


    }
}
