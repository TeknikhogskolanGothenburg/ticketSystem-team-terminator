﻿using System;
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
            List<EventTest> Test = new List<EventTest>();
            ITicketApi Getter = new TicketApi();
            Test = Getter.GetEvents();
               

            return View(Test);
        }
       
        public IActionResult CreateEvent()
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
