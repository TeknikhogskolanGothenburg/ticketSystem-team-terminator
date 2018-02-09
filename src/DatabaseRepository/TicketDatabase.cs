﻿using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TicketSystem.DatabaseRepository.Model;

namespace TicketSystem.DatabaseRepository
{
    public class TicketDatabase : ITicketDatabase
    {
        private readonly string CONN = @"Server=localhost\SQLEXPRESS;Database=TicketSystem;Trusted_Connection=True;";

        // Adriana
        public List<TicketEvent> AllEvents()
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<TicketEvent>("SELECT * FROM Events").ToList();
            }
        }

        public TicketEvent EventAdd(string name, string description)
        {
            string connectionString = CONN; /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into TicketEvents(EventName, EventHtmlDescription) values(@Name, @Description)", new { Name = name, Description = description });
                var addedEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID=@Id", new { Id = addedEventQuery }).First();
            }
        }

        public List<TicketEvent> EventsFind(string query)
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE EventName like '%" + query + "%' OR EventHtmlDescription like '%" + query + "%'").ToList();
            }
        }




        //Venue Methods
        public Venue VenueAdd(string name, string address, string city, string country)
        {
            string connectionString = CONN; /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country)", new { Name = name, Address= address, City = city, Country = country });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedVenueQuery }).First();
            }
        }
        public void VenueUpdate(Venue venue)
        {
            string connectionString = CONN; /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("UPDATE Venues SET [VenueName],[Address],[City],[Country] va (@Name,@Address, @City, @Country) WHERE [VenueID] = @ID ", new { Name = venue.VenueName, Address = venue.Address, City = venue.City, Country = venue.Country, ID = venue.VenueId }).First();
               
            }
        }

        public List<Venue> VenuesFind(string query)
        {
            string connectionString = CONN;    /*ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;*/
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueName like '%"+query+ "%' OR Address like '%" + query + "%' OR City like '%" + query + "%' OR Country like '%" + query + "%'").ToList();
            }
        }

        public List<Venue> VenuesAll()
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
    }
}
