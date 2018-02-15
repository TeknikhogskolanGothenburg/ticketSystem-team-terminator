using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.DatabaseRepository.Model
{
    public class TicketTransaction
    {
        //public int TransactionID { get; set; }
        //[Required]
        //[RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
        //public string LastName { get; set; }
        //[Required]
        //[RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
        //public string FirstName { get; set; }
        //[Required]
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string PaymentStatus { get; set; }
        //public int PaymentReferenceID { get; set; }



        [Required]
        public Ticket Tickets { get; set; }
        [Required]
        public TicketsToTransaction TicketsToTransactions { get; set; }

    }
}
