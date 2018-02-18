using TicketSystem.DatabaseRepository.Model;
using System.Collections.Generic;
using System;

namespace TicketSystem.DatabaseRepository
{
    // Event Metoder Måste matcha samma syntax i DatabaseKlassen
    public interface IDatabaseInterface
    {

        //Metoder för Events

        bool CreateEvent(Event value);
  
        List<EventTest> GetallEventsAvadible();


        //Get all orders
        List<Order> GetAllOrders();




    }
}
