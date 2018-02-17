using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketShopApplication.Models;
using TicketSystem.RestApiClient;
using TicketSystem.RestApiClient.Model;

namespace TicketShopApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order()
        {
            List<Order> allOrders = new List<Order>();
            ITicketApi getOrders = new TicketApi();
            allOrders = getOrders.GetOrders();


            return View(allOrders);
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
