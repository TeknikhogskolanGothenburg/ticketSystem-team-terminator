using RestSharp;
using System;
using System.Collections.Generic;
using TicketSystem.RestApiClient.Model;

namespace TicketSystem.RestApiClient
{
    public class TicketApi : ITicketApi
    {
        // Implemented using RestSharp: http://restsharp.org/

        public List<TicketEvent> TicketEventGet( )
        {
            var client = new RestClient("http://ticketshopwebapplication20180213124403.azurewebsites.net/");
            var request = new RestRequest("api/TicketEvent", Method.GET);
            var response = client.Execute<List<TicketEvent>>(request);
            return response.Data;
        }

        public Ticket TicketTicketIdGet(int ticketId)
        {
            var client = new RestClient("http://ticketshopwebapplication20180213124403.azurewebsites.net/");
            var request = new RestRequest("ticket/{id}", Method.GET);
            request.AddUrlSegment("id", ticketId);
            var response = client.Execute<Ticket>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", ticketId));
            }

            return response.Data;
        }
    }
}
