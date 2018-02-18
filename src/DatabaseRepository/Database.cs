using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TicketSystem.DatabaseRepository.Model;
using System;

namespace TicketSystem.DatabaseRepository
{
    public class Database : IDatabaseInterface

    {
        private readonly string CONN = @"Server=localhost\SQLEXPRESS;Database=TicketSystem;Trusted_Connection=True;";

        public bool CreateEvent(Event value)
        {

            string connectionString = CONN; /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    connection.Query("insert into TicketEvents(EventName, EventHtmlDescription) values(@Name, @Description)", new { Name = value.TicketEvents.EventName, Description = value.TicketEvents.EventHtmlDescription });
                    var TicketEventID = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                    connection.Query("insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country)", new { Name = value.Venues.VenueName, Address = value.Venues.Address, City = value.Venues.City, Country = value.Venues.Country });
                    var VenueID = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                    connection.Query("insert into TicketEventDates([TicketEventID],[Venueid],[EventStartDateTime]) values(@TicketEventID,@Venueid,@EventStartDateTime)", new { TicketEventID = TicketEventID, Venueid = VenueID, EventStartDateTime = value.TicketEventDates.EventStartDateTime });
                    var ticketEventDateID = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEventDates') AS Current_Identity").First();
                    for (int i = 0; i < value.Seats; i++)
                    {

                        connection.Query("Insert into SeatsAtEventDate ([TicketEventDateID]) values (@TicketEventDateID)", new { TicketEventDateID = ticketEventDateID });
                        var seatID = connection.Query<int>("SELECT IDENT_CURRENT ('SeatsAtEventDate') AS Current_Identity").First();
                        connection.Query("Insert into Tickets([SeatID]) values(@SeatID)", new { SeatID = seatID });

                    }
                    return true;
                }
                catch
                {
                    throw new Exception();
                    
                }

            }

        }
       
        public void EventUpdate(TicketEvent ticketEvent)
        {
            using (var connection = new SqlConnection(CONN))
            {
                connection.Open();
                connection.Query<TicketEvent>("UPDATE TicketEvent SET TicketEvent [EventName] = @EventName, [EventHtmlDescription] = @EventHtmlDescription WHERE TicketEventID = @TicketEventID", new {EventName = ticketEvent.EventName, EventHtmlDescription = ticketEvent.EventHtmlDescription, TicketEventID = ticketEvent.TicketEventID});
                
            }
        }

     
         public void TicketEventDateUpdate(int TicketEventDateID, int TicketEventID, int VenueId, DateTime EventStartDateTime)
         {
             string connectionString = CONN; /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
             using (var connection = new SqlConnection(connectionString))
             {
                 connection.Open();
                 connection.Query("UPDATE TicketEventDates SET [TicketEventID] = @ticketEventID, [VenueId] = @venueId, [EventStartDateTime] = @eventStartDateTime  WHERE[TicketEventDateID] = @ticketEventDateID; ", new { ticketEventID = TicketEventID, venueId = VenueId, eventStartDateTime = EventStartDateTime, ticketEventDateID = TicketEventDateID });                
            }
        }
 
        
        public void VenueDelete(int id)
        {
            string connectionString = CONN; /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("DELETE FROM Venues WHERE VenueID = @ID", new { ID = id });
            }

        }

        
        public List<EventTest> GetallEventsAvadible()
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    return connection.Query<EventTest>("SELECT TE.EventName,TE.EventHtmlDescription,TED.TicketEventDateID, TED.EventStartDateTime,V.VenueName, V.Address, V.City, V.Country FROM TicketEvents AS TE INNER JOIN TicketEventDates AS TED ON TE.TicketEventID = TED.TicketEventID INNER JOIN Venues AS V ON TED.VenueId = V.VenueID").ToList();
                }
                catch
                {
                    throw new Exception();
                }
                }
        }
       
        public List<EventTest> SearchEvent( string value)
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<EventTest>("SELECT TI.TicketID,  S.SeatID, TE.EventName,TE.EventHtmlDescription,TED.TicketEventDateID, TED.EventStartDateTime,V.VenueName, V.Address, V.City, V.Country FROM TicketEvents AS TE INNER JOIN TicketEventDates AS TED ON TE.TicketEventID = TED.TicketEventID INNER JOIN Venues AS V ON TED.VenueId = V.VenueID INNER JOIN SeatsAtEventDate AS S ON S.TicketEventDateID = TED.TicketEventDateID INNER JOIN Tickets AS TI ON TI.SeatID = S.SeatID Where TE.EventName like '%"+value+"%' OR TED.EventStartDateTime like '%"+value+"%' OR V.VenueName like '%"+value+"%' OR V.Address like '%"+value+"%'  OR V.City like '%+"+value+"+%'  OR V.Country like '%"+value+"%'").ToList();
            }
        }

        public List<Order> GetAllOrders()
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Order>("SELECT TTT.TicketID, TT.BuyerLastName,TT.BuyerFirstName,TT.BuyerAddress,TT.BuyerCity FROM TicketsToTransactions AS TTT INNER JOIN TicketTransactions AS TT ON TTT.TransactionID = TT.TransactionID ").ToList();
            }
        }

    }
}
