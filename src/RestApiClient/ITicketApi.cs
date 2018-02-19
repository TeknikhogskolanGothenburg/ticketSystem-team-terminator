using System.Collections.Generic;

using TicketSystem.RestApiClient.Model;

namespace TicketSystem.RestApiClient
{
    public interface ITicketApi
    {
        List<EventTest> GetEvents();
        List<EventForbooking> GetAllEventsToBooking();

       //Get all orders
       List<Order> GetOrders();
    }
}
