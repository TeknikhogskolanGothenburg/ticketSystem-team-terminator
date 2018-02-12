using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.DatabaseRepository.Model
{
  public  class Event
    {   [Required]
        public Venue Venues { get; set; }
        [Required]
        public  TicketEvent TicketEvents { get; set; }
        [Required]
        public TicketEventDate TicketEventDates { get; set; }
    }
}
