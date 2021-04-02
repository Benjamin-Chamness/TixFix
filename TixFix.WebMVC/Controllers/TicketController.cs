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
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateTicketService();

            if (service.CreateTicket(model))
            {
                TempData["SaveResult"] = "Your ticket was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Ticket could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTicketService();
            var model = svc.GetTicketById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTicketService();
            var detail = service.GetTicketById(id);
            var model = new TicketEdit
            {
                TicketId = detail.TicketId,
                Price = detail.Price,
                DateOfGame = detail.DateOfGame,
                IsAvailable = detail.IsAvailable
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, TicketEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.TicketId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTicketService();

            if (service.UpdateTicket(model))
            {
                TempData["SaveResutl"] = "Your ticket was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your ticket could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTicketService();
            var model = svc.GetTicketById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTicketService();
            service.DeleteTicket(id);
            TempData["SaveResult"] = "Your ticket was deleted.";
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