using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.RestApiClient.Model
{
    public class OrderList
    {
        [Required]
        public List<Ticket> Tickets = new List<Ticket>();
        [Required]
        public List<TicketsToTransaction> TicketsToTransactions = new List<TicketsToTransaction>();
        [Required]
        public List<TicketTransaction> TicketTransactions = new List<TicketTransaction>();
    }
}
