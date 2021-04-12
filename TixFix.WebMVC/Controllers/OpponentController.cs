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
    public class OpponentController : Controller
    {
        // GET: Opponent
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OpponentService(userId);
            var model = service.GetOpponents();

            return View(model);
        }

       
        public ActionResult Details(int id)
        {
            var svc = CreateOpponentService();
            var model = svc.GetOpponentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateOpponentService();
            var detail = service.GetOpponentById(id);
            var model = new OpponentEdit
            {
                EventId = detail.EventId,
                Name = detail.Name
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OpponentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EventId != id)
            {
                ModelState.AddModelError("", "Id does not match");
                return View(model);
            }
            var service = CreateOpponentService();

            if (service.UpdateOpponent(model))
            {
                TempData["SaveResult"] = "Opponent updated successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Opponent could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateOpponentService();
            var model = svc.GetOpponentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteOpponent(int id)
        {
            var service = CreateOpponentService();
            service.DeleteOpponent(id);
            TempData["SaveResult"] = "Opponent successfully deleted.";
            return RedirectToAction("Index");
        }




        //Helper methods    
        private OpponentService CreateOpponentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OpponentService(userId);
            return service;
        }
    }
}



