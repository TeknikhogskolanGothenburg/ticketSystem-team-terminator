using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TicketSystem.DatabaseRepository.Model;

namespace TicketSystem.DatabaseRepository
{
    public class Database : IDatabaseInterface

    {
        private readonly string CONN = @"Server=localhost\SQLEXPRESS;Database=TicketSystem;Trusted_Connection=True;";

        // Adriana
        public List<TicketEvent> FindEvent()
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents").ToList();
            }
        }

        // Här Behövs bara en VOid eller Bool 
        public void EventAdd(string name, string description)
        {
            string connectionString = CONN; /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into TicketEvents(EventName, EventHtmlDescription) values(@Name, @Description)", new { Name = name, Description = description });
                var addedEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                //return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID=@Id", new { Id = addedEventQuery }).First();
            }
        }

        public List<TicketEvent> FindEvent(string query)
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE EventName like '%" + query + "%' OR EventHtmlDescription like '%" + query + "%'").ToList();
            }
        }
        public void EventDelete(string id)
        {
            string connectionString = CONN;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                 connection.Query<TicketEvent>("DELETE * TicketEvents WHERE Id =" + id);
            }
        }
        public void EventUpdate(TicketEvent ticketEvent)
        {
            using (var connection = new SqlConnection(CONN))
            {
                //connection.Open();
                //connection.Execute(@"
                //    //UPDATE TicketEvents SET EventName = " + ticketEvent.EventName + ","
                    //+ "EventHtmlDescription = " + ticketEvent.EventHtmlDescription + ","
                    //+ "EventDelete = " + ticketEvent.EventDelete + ","
                    //+ "EventUpdate = " + ticketEvent.EventUpdate + " WHERE Id =" + ticketEvent.TicketEventId);
            }
        }

        /*
          public int TicketEventId { get; set; }
        public string EventName { get; set; }
        public string EventHtmlDescription { get; set; }
        public int EventDelete { get; set; }
        public string EventUpdate { get; set; }
             
             
             */

        // JOAKIM TESTAR
        public List<TicketEventDate> TicketEventDateFind(string query)
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<TicketEventDate>("SELCT * FROM TicketEventDate").ToList();
            }

        }

        public void TicketEventDateAdd(int ticketEventDateID, int ticketEventId, int venueId, int eventStartDateTime)
        {
            string connectionString = CONN; /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                connection.Query("insert into TicketEventDate([TicketEventDateID], [TicketEventID], [VenueID], [EventStartDateTime]) values(@TicketEventDateID, @TicketEventID, @VenueID, @EventStartDateTime)");
            }
        }

       /// Slut på Joakim testar
       ///

        //Venue Methods
        // Här räcker det med en void eller bool 
        public void VenueAdd(string name, string address, string city, string country)
        {
            string connectionString = CONN; /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country)", new { Name = name, Address= address, City = city, Country = country });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                //return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedVenueQuery }).First();
            }
        }

        public void VenueUpdate(int id, string name, string address, string city, string country)
        {
            string connectionString = CONN; /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("UPDATE Venues SET [VenueName] = @VenueName, [Address] = @Address,[City] = @City, [Country] = @Country  WHERE [VenueID] = @VenueID; ", new { VenueName = name, Address = address, City = city, Country=country, VenueID = id });                
            }
        }

        public List<Venue> FindVenue(string query)
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueName like '%"+query+ "%' OR Address like '%" + query + "%' OR City like '%" + query + "%' OR Country like '%" + query + "%'").ToList();
            }
        }

        public List<Venue> FindVenue()
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Venue>("SELECT * FROM Venues").ToList();
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

        //Tickets
        public List<int> FindSeatID(int ticketID)
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<int>("SELECT * FROM Tickets WHERE TicketID = @TicketID", new { TicketID = ticketID }).ToList();
            }
        }

        public List<int> AllTickets()
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<int>("SELECT * FROM Tickets").ToList();
            }
        }

    }
}
