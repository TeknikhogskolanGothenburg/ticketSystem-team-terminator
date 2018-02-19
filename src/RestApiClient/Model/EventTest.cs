using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.RestApiClient.Model
{
      public  class EventTest
    {
        [Required]
        public int TicketEventDateID { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string EventHtmlDescription { get; set; }
        [Required]
        public DateTime EventStartDateTime { get; set; }
        [Required]
        public string VenueName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int PeopleCount { get; set; }

    }
}
