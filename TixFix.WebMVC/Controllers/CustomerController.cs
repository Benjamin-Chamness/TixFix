using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TixFix.Models;

namespace TixFix.WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        [Authorize]
        // GET: Customer
        public ActionResult Index()
        {
            var model = new CustomerListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}