﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TixFix.Models;
using TixFix.Services;

namespace TixFix.WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        [Authorize]
        // GET: Customer
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            var model = service.GetCustomers();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateCustomerService();

            if(service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Customer created successfully";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Customer could not be created");
                
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var model = new CustomerEdit
            {
                CustomerId = detail.CustomerId,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                Email = detail.Email
            };
            return View(model);
        }

        //Helper Method

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }

        


    }
}