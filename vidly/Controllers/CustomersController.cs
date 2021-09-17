using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.Static_data;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var Columns = new List<string>
            {
                "Customer"
            };
            var customers = StaticData.Customers;
            var customersTable = new TableViewModel<Customer>
            {
                Columns = Columns,
                Rows = customers
            };

            return View(customersTable);
        }

        public ActionResult Details(int Id)
        {
            var customer = StaticData.Customers.Find(c => c.Id == Id);
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