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
        List<TicketEvent> FindEvent(string query); // Retunerar en lista av TicketEvent
        List<TicketEvent> FindEvent(); // Retunerar en lista av TicketEvent

        //Metoder för Venues
        int VenueAdd(string name, string address, string city, string country); // Retunerar en siffra
        List<Venue> FindVenue(string query); //Retunerar en lista av Venue
        List<Venue> FindVenue(); //Retunerar en lista av Venue


        //Metoder för Tickets
        List<Ticket> AllTickets();
        List<Ticket> FindSeatID(int ticketID); //Retunerar en lista av seats
        int TicketAdd(int seatID);


        ////Metoder för TicketEventDate
        int TicketEventDate(int TicketEventID, int VenueID, DateTime EventStarDate ); // Retunerar Inget
        List<TicketEventDate> FindTicketEventDate();
        List<TicketEventDate> FindTicketEventDate(string query);
        // SetEventCreaTOR


        void SeatsAtEventDateAdd(int ticketEventDateID);
      

        //List<TicketEventDate> FindTicketEventDate(string query);
        //List<TicketEventDate> FindTicketEventDate();
        //void TicketEventDateDelete(int id);
        //void TicketEventDateUpdate(TicketEventDate ticketEventDate);
        //TicketEventDate TicketEventDateAdd(int ticketEventDateId, int ticketEventId, int venueId, int eventStartDateTime);


    }
}
