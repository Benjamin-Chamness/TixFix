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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OpponentCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OpponentService(userId);

            service.CreateOpponent(model);

            return RedirectToAction("Index");
        }
    }
}