using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketSystem.DatabaseRepository.Model
{
    //Join Tabell
    class SeatsEventDate
    {
        public int SeatID { get; set; }
        [Required]
        public int TicketEventDay { get; set; }
    }
}
