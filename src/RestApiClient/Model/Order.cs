using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.RestApiClient.Model
{
    public class Order
    {
         
         public int TicketID { get; set; }
         public string BuyerLastName { get; set; }
         public string BuyerFirstName { get; set; }
         public string BuyerAddress { get; set; }
         public string BuyerCity { get; set; }
           
        
    }
}
