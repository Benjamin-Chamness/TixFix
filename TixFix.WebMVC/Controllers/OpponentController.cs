using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TixFix.Models;

namespace TixFix.WebMVC.Controllers
{
    [Authorize]
    public class OpponentController : Controller
    {
        // GET: Opponent
        public ActionResult Index()
        {
            var model = new OpponentListItem[0];
            return View(model);
        }
    }
}