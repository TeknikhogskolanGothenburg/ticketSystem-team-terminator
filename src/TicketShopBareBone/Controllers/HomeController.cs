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

        private ITicketApi ClienApi = new TicketApi ();

        public HomeController()
        {
          
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

        // visar en lista på event som finns att boka 
        public IActionResult ViewAll()
        {


            return View(ClienApi.GetAllEventsToBooking());

        }

        public IActionResult Details(int id)
        {
            return View();
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
