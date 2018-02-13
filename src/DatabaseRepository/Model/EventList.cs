using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.DatabaseRepository.Model
{
   public class EventList
    {
        [Required]
        public List<Venue> Venues = new List<Venue>();

        [Required]
        public List<TicketEvent> TicketEvents = new List<TicketEvent>();
        [Required]
        public List<TicketEventDate> TicketEventDates = new List<TicketEventDate>();
    }
}
