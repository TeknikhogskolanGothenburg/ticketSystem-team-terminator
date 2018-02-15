using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.DatabaseRepository.Model
{
    public class TicketTransactionList
    {
        [Required]
        public List<TicketsToTransaction> TicketsToTransactions = new List<TicketsToTransaction>();

        [Required]
        public List<Ticket> Tickets = new List<Ticket>();
        [Required]

        public List<TicketEventDate> TicketEventDates = new List<TicketEventDate>();

    }
}
