using TicketSystem.DatabaseRepository.Model;
using System.Collections.Generic;
using System;
using TicketSystem.PaymentProvider;

namespace TicketSystem.DatabaseRepository
{
    // Event Metoder Måste matcha samma syntax i DatabaseKlassen
    public interface IDatabaseInterface
    {

        //Metoder för Events

        bool CreateEvent(Event value);
        List<OrderRefence> GetOrdesByID(int Id);
        List<EventTest> GetallEvents();
         List<EventForbooking> GetallEventsAvadible();

        List<EventTest> AllEvents();

        List<EventTest> SearchEvent(string value);
        void CreateOrder(Order value, Payment e);
        bool CheckTicket(int TickedID);

        //Get all orders
        List<Order> GetAllOrders();




    }
}
