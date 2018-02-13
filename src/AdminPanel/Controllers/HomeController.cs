using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminPanel.Models;
using Microsoft.AspNetCore.Authorization;
using TicketSystem.RestApiClient.Model;
using TicketSystem.RestApiClient;

namespace AdminPanel.Controllers
{

    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetEvents()
        {
            List<TicketEvent> Events = new List<TicketEvent>();
            ITicketApi Db = new TicketApi();
           Events = Db.TicketEventGet();


            return View(Events);
        }
       
        public IActionResult CreteEvent()
        {
            ViewData["Message"] = "Your application description page.";

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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
