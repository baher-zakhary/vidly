﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.Static_data;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = ApplicationDbContext.Create();
        }
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        // GET: Customers
        public ActionResult Index()
        {
            //var customers = _dbContext.Customers.ToList();    // Lazy loading
            var customers = _dbContext.Customers.Include(c => c.MembershipType).ToList();   // use Include for eager loading, import include from System.Data.Entity

            return View(customers);
        }

        public ActionResult Details(int Id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer != null)
            {
                return View(customer);
            } 
            else
            {
                return HttpNotFound();
            }
        }
    }
}