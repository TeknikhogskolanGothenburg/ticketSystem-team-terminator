using System;
using System.ComponentModel.DataAnnotations;

namespace TicketSystem.DatabaseRepository.Model
{
    public class TicketEventDate
    {
        public int TicketEventDateID { get; set; }
        [Required]
        public int TicketEventID { get; set; }
        [Required]
        public int VenueId{get;set; }
        [Required]
        public string EventStartDateTime { get; set; }
    }
}
