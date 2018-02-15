using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.RestApiClient.Model
{
    public class Order
    {
        [Required]
        public Ticket Ticket { get; set; }
        [Required]
        public TicketsToTransaction TicketsToTransaction { get; set; }
        [Required]
        public TicketTransaction TicketTransaction { get; set; }
    }
}
