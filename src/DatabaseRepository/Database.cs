using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TicketSystem.DatabaseRepository.Model;
using System;
using TicketSystem.PaymentProvider;

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
                        connection.Query("Insert into Tickets([SeatID],[IsTaken]) values(@SeatID, @IsTaken)", new { SeatID = seatID, IsTaken = "0" });

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
                connection.Query<TicketEvent>("UPDATE TicketEvent SET TicketEvent [EventName] = @EventName, [EventHtmlDescription] = @EventHtmlDescription WHERE TicketEventID = @TicketEventID", new { EventName = ticketEvent.EventName, EventHtmlDescription = ticketEvent.EventHtmlDescription, TicketEventID = ticketEvent.TicketEventID });

            }
        }

        // under uveckling 
        public void TicketEventDateUpdate(int TicketEventDateID, int TicketEventID, int VenueId, DateTime EventStartDateTime)
        {
            string connectionString = CONN; /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
               
                connection.Open();
                connection.Query("SELECT  V.VenueID, TE.TicketEventID FROM TicketEvents AS TE INNER JOIN TicketEventDates AS TED ON TE.TicketEventID = TED.TicketEventID INNER JOIN Venues AS V ON TED.VenueId = V.VenueID Where TED.TicketEventDateID = '@ID'", new { ID = TicketEventDateID }).First();
            }
        }

        public bool CheckTicket(int TickedID)
        {
            string connectionString = CONN; /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var Status = connection.Query<int>("SELECT IsTaken FROM Tickets WHERE TicketID = @TicketID", new { TicketID = TickedID }).First();
                if (Status == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public void CreateOrder(Order value, Payment e)
        {
            string connectionString = CONN; /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into TicketTransactions ([BuyerLastName],[BuyerFirstName],[BuyerAddress],[BuyerCity],[PaymentStatus],[PaymentReferenceId]) values(@BuyerLastName,@BuyerFirstName,@BuyerAddress,@BuyerCity,@PaymentStatus,@PaymentReferenceId)", new { BuyerLastName = value.BuyerLastName, BuyerFirstName = value.BuyerFirstName, BuyerAddress = value.BuyerAddress, BuyerCity = value.BuyerCity, PaymentStatus = e.PaymentStatus, PaymentReferenceId = e.PaymentReference });
                var transactionID = connection.Query<int>("SELECT IDENT_CURRENT ('TicketTransactions') AS Current_Identity").First();
                connection.Query("insert into TicketsToTransactions ([TransactionID],[TicketID]) values(@TransactionID,@TicketID)", new { TransactionID = transactionID, TicketID = value.TicketID });
                connection.Query<int>("UPDATE Tickets SET [IsTaken] = @IsTaken WHERE TicketID = @TicketID", new { IsTaken = 1, TicketID = value.TicketID });
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
        public List< OrderRefence> GetOrdesByID(int Id)
        {

            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    return connection.Query<OrderRefence>(" SELECT P.BuyerFirstName , P.BuyerLastName,P.PaymentReferenceId, TOTRAC.TransactionID, TT.TicketID, TE.EventName,TE.EventHtmlDescription,TED.TicketEventDateID, TED.EventStartDateTime,V.VenueName, V.Address, V.City, V.Country FROM TicketEvents AS TE INNER JOIN TicketEventDates AS TED ON TE.TicketEventID = TED.TicketEventID INNER JOIN Venues AS V ON TED.VenueId = V.VenueID INNER JOIN SeatsAtEventDate AS S ON S.TicketEventDateID = TED.TicketEventDateID INNER JOIN Tickets AS TT ON TT.SeatID = s.SeatID INNER JOIN TicketsToTransactions AS  TOTRAC ON TOTRAC.TicketID = TT.TicketID INNER JOIN TicketTransactions AS  p ON p.TransactionID = TOTRAC.TransactionID Where TED.TicketEventDateID = @ID ", new { ID = Id }).ToList();
                }
                catch
                {
                    throw new Exception();
                }
            }

           

        }
        public List<EventTest> GetallEvents()
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    List<EventTest> e = new List<EventTest>();
                   
                   e = connection.Query<EventTest>("SELECT TE.EventName,TE.EventHtmlDescription,TED.TicketEventDateID, TED.EventStartDateTime,V.VenueName, V.Address, V.City, V.Country FROM TicketEvents AS TE INNER JOIN TicketEventDates AS TED ON TE.TicketEventID = TED.TicketEventID INNER JOIN Venues AS V ON TED.VenueId = V.VenueID ").ToList();
                foreach(var item in e)
                    {
                       e[e.IndexOf(item)].PeopleCount = connection.Query<int>("SELECT COUNT(TI.IsTaken ) FROM TicketEvents AS TE INNER JOIN TicketEventDates AS TED ON TE.TicketEventID = TED.TicketEventID INNER JOIN Venues AS V ON TED.VenueId = V.VenueID INNER JOIN SeatsAtEventDate AS S ON S.TicketEventDateID = TED.TicketEventDateID INNER JOIN Tickets AS TI ON TI.SeatID = S.SeatID Where TI.IsTaken = '1' AND TED.TicketEventDateID = '" + item.TicketEventDateID +"'").First();
                    }

                    return e;

                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        
        public List<EventForbooking> GetallEventsAvadible()
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    return connection.Query<EventForbooking>("SELECT TI.TicketID, TI.IsTaken , S.SeatID, TE.EventName,TE.EventHtmlDescription,TED.TicketEventDateID, TED.EventStartDateTime,V.VenueName, V.Address, V.City, V.Country FROM TicketEvents AS TE INNER JOIN TicketEventDates AS TED ON TE.TicketEventID = TED.TicketEventID INNER JOIN Venues AS V ON TED.VenueId = V.VenueID INNER JOIN SeatsAtEventDate AS S ON S.TicketEventDateID = TED.TicketEventDateID INNER JOIN Tickets AS TI ON TI.SeatID = S.SeatID").ToList();
                }
                catch
                {
                    throw new Exception();
                }
                }
        }

        public List<EventTest> AllEvents()
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<EventTest>("SELECT TE.EventName,TE.EventHtmlDescription,TED.TicketEventDateID, TED.EventStartDateTime,V.VenueName, V.Address, V.City, V.Country, TP.TicketPrice FROM TicketEvents AS TE INNER JOIN TicketEventDates AS TED ON TE.TicketEventID = TED.TicketEventID INNER JOIN Venues AS V ON TED.VenueId = V.VenueID INNER JOIN TicketPrice AS TP ON TE.TicketEventID = TP.TicketEventID").ToList();
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
