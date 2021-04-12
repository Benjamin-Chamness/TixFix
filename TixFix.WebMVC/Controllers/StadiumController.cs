using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TixFix.Models;

namespace TixFix.WebMVC.Controllers
{
    [Authorize]
    public class StadiumController : Controller
    {
        // GET: Stadium
        public ActionResult Index()
        {
            var model = new StadiumListItem[0];
            return View(model);
        }
    }
}