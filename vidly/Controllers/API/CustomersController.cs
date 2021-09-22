using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.Models;

namespace vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbContext { get; set; }

        public CustomersController()
        {
            _dbContext = ApplicationDbContext.Create();
        }

        // GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        // GET /api/customers/{id}
        public Customer GetCustomer(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }

        // POST /api/customers
        [HttpPost] // annotation should be used becase action name is not PostCustomer
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid == true)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        // PUT /api/customers/1
        [HttpPut]
        public Customer UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            customerInDb.Name = customer.Name;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.Birthdate = customer.Birthdate;
            _dbContext.SaveChanges();
            return customer;
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _dbContext.Customers.Remove(customerInDb);
            _dbContext.SaveChanges();
        }
    }
}
