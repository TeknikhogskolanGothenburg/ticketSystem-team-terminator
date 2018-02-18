using TicketSystem.DatabaseRepository.Model;
using System.Collections.Generic;
using System;

namespace TicketSystem.DatabaseRepository
{
    // Event Metoder Måste matcha samma syntax i DatabaseKlassen
    public interface IDatabaseInterface
    {
       
       //Metoder för Events
      
        int EventAdd(string name, string description); // Retunerar en siffra
      
        //Metoder för Venues
        int VenueAdd(string name, string address, string city, string country); // Retunerar en siffra
        List<Venue> FindVenue(string query); //Retunerar en lista av Venue
        List<Venue> AllVenues(); //Retunerar en lista av Venue

        


        //Metoder för Tickets
        //List<Ticket> AllTickets();
        //List<Ticket> FindSeatID(int ticketID); //Retunerar en lista av seats
        //int TicketAdd(int seatID);


        ////Metoder för TicketEventDate
        int TicketEventDate(int TicketEventID, int VenueID, DateTime EventStarDate ); // Retunerar Inget
        List<TicketEventDate> FindTicketEventDate();
        List<TicketEventDate> FindTicketEventDate(string query);

        List<EventTest> GetallEventsAvadible();
        List<EventTest> SearchEvents(string query);

        // SetEventCreaTOR


        void SeatsAtEventDateAdd(int ticketEventDateID);

        //Get all orders
        List<Order> GetAllOrders();




    }
}
