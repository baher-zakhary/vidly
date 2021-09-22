using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.DTOs;
using vidly.Models;

namespace vidly.Controllers.API
{
    /*
     * Benefits of using DTOs (Data transfer objects):
     * -----------------------------------------------
     * 1- Application domain models which are considered implementation details
     * 2- Domain models should not be used with APIs
     * 3- Our domain models can change frequently as we implement new features through (renaming, removing) properties
     *    in our application, thus breaking existing clients that depend on our APIs
     * 4- So DTOs make the contract of our API as stable as possible
     * 5- Since DTOs are public contracts they should be changed carefully and at slower pace than domain models
     * 6- Therefore DTOs should not depend on domain models, only on primitive types and other DTOs
     * 7- Can be used safely with Auto mapper without exposing sensitive properties to attacks
     * 8- APIs should never receive or return domain objects
     */
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbContext { get; set; }

        public CustomersController()
        {
            _dbContext = ApplicationDbContext.Create();
        }

        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _dbContext.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/customers/{id}
        public CustomerDto GetCustomer(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        // POST /api/customers
        [HttpPost] // annotation should be used becase action name is not PostCustomer
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid == true)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
        }

        // PUT /api/customers/1
        [HttpPut]
        public CustomerDto UpdateCustomer(int id, CustomerDto customerDto)
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

            Mapper.Map(customerDto, customerInDb);  // We pass customerInDb to mapper to update it

            _dbContext.SaveChanges();
            return customerDto;
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
