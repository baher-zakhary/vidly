using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.Static_data;
using vidly.ViewModels;

// Use MVC controller if you want to return Markup (HTML files)
namespace vidly.Controllers
{
    // Apply authorization on all controller actions
    //[Authorize]
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

        // Apply authorization on an action
        //[Authorize]
        // GET: Customers
        public ActionResult Index()
        {
            //var customers = _dbContext.Customers.ToList();    // Lazy loading
            //var customers = _dbContext.Customers.Include(c => c.MembershipType).ToList();   // use Include for eager loading, import include from System.Data.Entity

            return View(/*customers*/);
        }

        public ActionResult Details(int Id)
        {
            var customer = _dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);
            if (customer != null)
            {
                return View(customer);
            } 
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult New()
        {
            var membershipTypes = _dbContext.MembershipTypes.ToList();
            var newCustomerViewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", newCustomerViewModel);
        }

        // ASP Maps view Model to view Model in method parameter
        // public ActionResult Create(NewCustomerViewModel newCustomerViewModel)

        // ASP is also smart enough to map Customer from inside View model to customer in method parameter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var customerFormViewModel = new CustomerFormViewModel 
                {
                    Customer = customer,
                    MembershipTypes = _dbContext.MembershipTypes.ToList()
                };

                return View("CustomerForm", customerFormViewModel);
            }

            if (customer.Id == 0)   // Add new customer
            {
                _dbContext.Customers.Add(customer);
            }
            else    // Edit customer
            {
                var customerToUpdate = _dbContext.Customers.Single(c => c.Id == customer.Id);    // Here we use Single so an exception is thrown if customer is not found

                /*
                 * One way to update our models is:
                 * 
                 * TryUpdateModel(customerToUpdate, "", new string[] { "Name", "Email" });
                 * 
                 * Which is not good as it opens up security holes in our application because it updates all properties given through request key/value dictionary
                 * Allowing hackers to modify requests and update properties they are not allowed to
                 * This could be fixed by providing fields to update as Magic strings new string[] { "Name", "Email" }
                 * Which fixes this security vulnerability but introduces another issue which is if we renamed these properties names, the magic strings will not be
                 * automatically update causing our code to break if we don't update them manually.
                 */

                // Another approach is setting the properties manually
                customerToUpdate.Name = customer.Name;
                customerToUpdate.Birthdate = customer.Birthdate;
                customerToUpdate.MembershipTypeId = customer.MembershipTypeId;
                customerToUpdate.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

                // Third approach is to use a Mapper with a DTO in method parameters to map DTO fields into our objectToUpdate
                /*
                 *  Mapper.Map(customerDTO, customerToUpdate);
                 */
                // and the DTO will limit the properties that will be updated avoid the security vulnerability we mentioned earlier
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            var newCustomerViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _dbContext.MembershipTypes.ToList()
            };
            return View("CustomerForm", newCustomerViewModel); // Override default behavior of return View(); which will go to Edit View, but with return View("CustomerForm"); goes to CustomerForm view
        }
    }
}