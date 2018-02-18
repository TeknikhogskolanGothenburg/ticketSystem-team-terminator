using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketShopBareBone.Models;
using TicketSystem.RestApiClient;
using TicketSystem.RestApiClient.Model;

namespace TicketShopBareBone.Controllers
{
    public class HomeController : Controller
    {

        private readonly TicketApi ticketApi;

        public HomeController()
        {
            ticketApi = new TicketApi();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult ViewAll()
        {
            
            var allEvents = ticketApi.GetEvents();
            return View(allEvents);
        }

        public IActionResult Details(int id)
        {
            var eventTests = ticketApi.GetEvents();
            var eventTest = eventTests.FirstOrDefault(x=> x.TicketEventDateID == id);
            return View(eventTest);

        }

        //public IActionResult Buy(int price)
        //{

        //}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
