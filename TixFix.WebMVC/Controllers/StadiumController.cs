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
    public class StadiumController : Controller
    {
        // GET: Stadium
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StadiumService(userId);
            var model = service.GetStadiums();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateStadiumService();
            var model = svc.GetStadiumById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateStadiumService();
            var detail = service.GetStadiumById(id);
            var model = new StadiumEdit
            {
                StadiumId = detail.StadiumId,
                StadiumName = detail.StadiumName,
                Location = detail.Location
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StadiumEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.StadiumId != id)
            {
                ModelState.AddModelError("", "Id does not match.");
                return View(model);
            }

            var service = CreateStadiumService();

            if (service.UpdateStadium(model))
            {
                TempData["SaveResult"] = "Stadium updated successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Stadium could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateStadiumService();
            var model = svc.GetStadiumById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStadium(int id)
        {
            var service = CreateStadiumService();
            service.DeleteStadium(id);
            TempData["SaveResult"] = "Stadium successfully deleted.";
            return RedirectToAction("Index");
        }


        //Helper method:
        private StadiumService CreateStadiumService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StadiumService(userId);
            return service;
        }
    }
}
