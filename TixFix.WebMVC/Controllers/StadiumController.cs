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


        //Helper method:
        private StadiumService CreateStadiumService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StadiumService(userId);
            return service;
        }
    }
}
