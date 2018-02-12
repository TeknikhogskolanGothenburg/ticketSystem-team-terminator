﻿using System;
using System.Collections.Generic;
using TicketSystem.RestApiClient.Model;

namespace TicketSystem.RestApiClient
{
    public interface ITicketApi
    {
       
     

        /// <summary>
        /// Get a ticket by ID from the system Returns a single ticket
        /// </summary>
        /// <param name="ticketId">ID of the ticket</param>
        /// <returns></returns>
        Ticket TicketTicketIdGet(int ticketId);
        List<TicketEvent>TicketEventGet();
    }
}
