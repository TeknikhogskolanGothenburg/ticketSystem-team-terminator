using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.DatabaseRepository.Model
{
  public  class Order
    {
        [Required]
        public int TicketID { get; set; }
        [Required]
        public string BuyerLastName { get; set; }
        [Required]
        public string BuyerFirstName { get; set; }
        [Required]
        public string BuyerAddress{ get; set; }
        [Required]
        public string BuyerCity { get; set; }
        [Required]
        public decimal amountToPay { get; set; }
        [Required]
        public string valuta { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
