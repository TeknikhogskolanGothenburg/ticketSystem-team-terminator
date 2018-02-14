﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.DatabaseRepository.Model
{
    public class Ticket
    {
        public int TicketID { get; set; }
        [Required]
        public int SeatID { get; set; }
    }
}
