using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketShopWebApplication.Models;
using TicketSystem.RestApiClient;
using TicketSystem.RestApiClient.Model;



namespace TicketShopWebApplication.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
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

        public IActionResult ViewAll()
        {
            List<EventTest> allEvents = new List<EventTest>();
            ITicketApi getEvents = new TicketApi();
            allEvents = getEvents.GetEvents();
            return View(allEvents);
        }

        //public List<EventTest> AllEvents()
        //{
        //    List<EventTest> allEvents = new List<EventTest>();
        //    ITicketApi getEvents = new TicketApi();
        //    allEvents = getEvents.GetEvents();
        //    return allEvents.ToList<EventTest>();
        //}

        //IEnumerable<EventList> GetAllEvents()
        //{
        //    List<EventList> eventList = new List<EventList>();
        //    return eventList;
        //}

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}