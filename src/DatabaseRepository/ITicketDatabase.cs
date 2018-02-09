using TicketSystem.DatabaseRepository.Model;
using System.Collections.Generic;

namespace TicketSystem.DatabaseRepository
{
    public interface ITicketDatabase
    {
        // Start Adriana 
        /// <summary>
        /// Add a new Event to the database
        /// </summary>
        /// <param name="name">Name of the event</param>
        /// <param name="description">A desription of the event, html markup of the event is allowed</param>
        /// <returns>An object representing the newly created TicketEvent</returns>
        TicketEvent EventAdd(string name, string description);


   
        List<TicketEvent> AllEvents();
        List<TicketEvent> EventsFind(string query);
        // Slut Adriana

      


        /// <summary>
        /// Add a new venue to the database
        /// </summary>
        /// <param name="name">Name of the venue</param>
        /// <param name="address">Physical address of the venue</param>
        /// <param name="city">City part of the adress</param>
        /// <param name="country">Country part of the adress</param>
        /// <returns>An object representing the newly created Venue</returns>
        Venue VenueAdd(string name, string address, string city, string country);


        /// <summary>
        /// Find all venus matching the query
        /// </summary>
        /// <param name="query">A text which is user i looking for in the venues</param>
        /// <returns>A list of venus matching the query</returns>
        List<Venue> VenuesFind(string query);
       
        List<Venue> VenuesAll();

        void VenueUpdate(Venue venue);

        void VenueDelete(int id);

        //Joakim testing testing

        List<TicketEventDate> TicketEventDateFind(string query);
        List<TicketEventDate> TicketEventDateAll();

        /// <summary>
        /// Add a new ticketeventdate to the database
        /// </summary>
        /// <param name="ticketEventDateId">Name of the event</param>
        /// <param name="ticketEventId">Physical address of the venue</param>
        /// <param name="venueId">City part of the adress</param>
        /// <param name="eventStartDateTime">Country part of the adress</param>
        /// <returns>An object representing the newly created TicketEventDate</returns>
     
        TicketEventDate TicketEventDateAdd(int ticketEventDateId, int ticketEventId, int venueId, time eventStartDateTime);


        void TicketEventDateUpdate(TicketEventDate ticketEventDate);

        void TicketEventDateDelete(int id);
        // Joakim Testar
    }
}
