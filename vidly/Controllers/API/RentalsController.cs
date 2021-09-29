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
    public class RentalsController : ApiController
    {
        public ApplicationDbContext _dbContext { get; set; }

        public RentalsController()
        {
            _dbContext = ApplicationDbContext.Create();
        }

        [HttpGet]
        public IHttpActionResult GetRentals()
        {
            var rentals = _dbContext.Rentals.ToList().Select(Mapper.Map<Rental, RentalDto>);
            return Ok(rentals);
        }

        public IHttpActionResult GetRentals(int customerId)
        {
            var rentals = _dbContext.Rentals.Where(r => r.CustomerId == customerId).ToList().Select(Mapper.Map<Rental, RentalDto>);
            return Ok(rentals);
        }
    }
}
