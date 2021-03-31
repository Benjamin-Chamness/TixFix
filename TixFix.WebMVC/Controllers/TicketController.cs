using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TixFix.Models;
using TixFix.Services;

namespace TixFix.WebMVC.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TicketService(userId);
            var model = service.GetTickets();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateTicketService();

            service.CreateTicket(model);
            return RedirectToAction("Index");

        }

        private TicketService CreateTicketService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TicketService(userId);
            return service;
        }
    }
}