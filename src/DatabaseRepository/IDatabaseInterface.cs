using TicketSystem.DatabaseRepository.Model;
using System.Collections.Generic;

namespace TicketSystem.DatabaseRepository
{
    // Event Metoder Måste matcha samma syntax i DatabaseKlassen
    public interface IDatabaseInterface
    {
       
       //Metoder för Events
        void EventUpdate(TicketEvent ticketevent); // Retunerar Inget 
        void EventDelete(string id);// Retunerar Inget 
        void EventAdd(string name, string description); // Retunerar Inget 
        List<TicketEvent> FindEvent(string query); // Retunerar en lista av TicketEvent
        List<TicketEvent> FindEvent(); // Retunerar en lista av TicketEvent

        //Metoder för Venues
        void VenueAdd(string name, string address, string city, string country); // Retunerar Inget 
        void VenueUpdate(int id, string name, string address, string city, string country);  // Retunerar Inget 
        void VenueDelete(int id);  // Retunerar Inget 
        List<Venue> FindVenue(string query); //Retunerar en lista av Venue
        List<Venue> FindVenue(); //Retunerar en lista av Venue


        //Metoder för Tickets
        List<int> AllTickets();
        List<int> FindSeatID(int ticketID); //Retunerar en lista av seats
        void TicketAdd(int seatID);


        ////Metoder för TicketEventDate
        //List<TicketEventDate> FindTicketEventDate(string query);
        //List<TicketEventDate> FindTicketEventDate();
        //void TicketEventDateDelete(int id);
        //void TicketEventDateUpdate(TicketEventDate ticketEventDate);
        //TicketEventDate TicketEventDateAdd(int ticketEventDateId, int ticketEventId, int venueId, int eventStartDateTime);


    }
}
