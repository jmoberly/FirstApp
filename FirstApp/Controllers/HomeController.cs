﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstApp.ViewModels;
using FirstApp.DAL;
using FirstApp.Models;
using ModelState = System.Web.Http.ModelBinding.ModelState;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Contoso University.";

            return View();
        }

        public ActionResult About()
        {
            var data = from student in db.Students
                       group student by student.EnrollmentDate into dateGroup
                       select new EnrollmentDateGroup()
                       {
                           EnrollmentDate = dateGroup.Key,
                           StudentCount = dateGroup.Count()
                       };
            return View(data);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListCustomers()
        {
            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer()
                          {
                              Id = 1,
                              CompanyName = "Volvo",
                              ContactNo = "123-123-1234",
                              ContactPerson = "Some Guy",
                              Description = "This is a car company that makes cars."
                          });
            customers.Add(new Customer()
            {
                Id = 2,
                CompanyName = "Microsoft",
                ContactNo = "123-123-1235",
                ContactPerson = "Bill Gates",
                Description = "Winodws and XBox. All of that fun stuff."
            });
            customers.Add(new Customer()
            {
                Id = 3,
                CompanyName = "Apple",
                ContactNo = "123-555-1234",
                ContactPerson = "Steve Jobs",
                Description = "Macs and iPods. Think Different."
            });

            return View(customers);

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
