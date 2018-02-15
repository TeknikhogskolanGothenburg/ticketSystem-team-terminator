using RestSharp;
using System;
using System.Collections.Generic;

using TicketSystem.RestApiClient.Model;

namespace TicketSystem.RestApiClient
{
    public class TicketApi : ITicketApi
    {
        // Implemented using RestSharp: http://restsharp.org/

        public List<EventTest> GetEvents( )
        {

            var client = new RestClient("http://localhost:55792/");
            var request = new RestRequest("api/Event", Method.GET);
            var response = client.Execute<List<EventTest>>(request);
            return response.Data;
        }
      
        //public Ticket TicketTicketIdGet(int ticketId)
        //{
        //    var client = new RestClient("http://localhost:55792/");
        //    var request = new RestRequest("ticket/{id}", Method.GET);
        //    request.AddUrlSegment("id", ticketId);
        //    var response = client.Execute<Ticket>(request);

        //    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        //    {
        //        throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", ticketId));
        //    }

        //    return response.Data;
        //}
    }
}
