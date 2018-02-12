using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.RestApiClient.Model
{
 public   class TicketEvent
    {
        public int TicketEventID { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string EventHtmlDescription { get; set; }
    }
}
