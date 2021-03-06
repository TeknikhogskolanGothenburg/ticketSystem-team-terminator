﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TicketSystem.RestApiClient.Model
{
    public class TicketEventDate
    {
        public int TicketEventDateID { get; set; }
        [Required]
        public int TicketEventID { get; set; }
        [Required]
        public int VenueId{get;set; }
        [Required]
        public DateTime EventStartDateTime { get; set; }
    }
}
