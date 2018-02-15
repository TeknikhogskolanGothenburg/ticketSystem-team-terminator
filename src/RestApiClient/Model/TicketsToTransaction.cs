using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.RestApiClient.Model
{
    public class TicketsToTransaction
    {
        public int TicketID { get; set; }
        public int TransactionID { get; set; }
    }
}
