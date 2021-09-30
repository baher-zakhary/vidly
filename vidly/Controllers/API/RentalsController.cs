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
    [RoutePrefix("api/rentals")]
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

        //public IHttpActionResult GetRentals(int customerId)
        //{
        //    var rentals = _dbContext.Rentals.Where(r => r.CustomerId == customerId).ToList().Select(Mapper.Map<Rental, RentalDto>);
        //    return Ok(rentals);
        //}

        /*
         * Defensive approach
         * ------------------
         * where we validate on everything and return clear error messages
         * Good for Public APIs
         * Results in more complicated/polluted code with extra validations
         */
        [HttpPost]
        [Route("CreateRentalDefensiveApproach")]
        public IHttpActionResult CreateRentalDefensiveApproach(RentalDto rentalDto)
        {
            if (rentalDto.MovieIds == null || rentalDto.MovieIds.Count == 0)
            {
                return BadRequest("No movie Ids have been given");
            }

            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);
            
            if (customer == null)
            {
                return BadRequest("Customer ID is not valid");
            }

            var movies = _dbContext.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != rentalDto.MovieIds.Count)
            {
                return BadRequest("One or more movie Ids are Invalid");
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("One or more movie is not avaliable for rent");
                }

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _dbContext.Rentals.Add(rental);
                movie.NumberAvailable --;
            }
            _dbContext.SaveChanges();
            return Ok();
        }

        /*
         * Optimistic approach
         * ------------------
         * where we don't validate on everything and return vague error messages
         * Good for Internal APIs
         * Provides an implementation that protects our application but is simpler
         * No need for extra validation code
         */
        [HttpPost]
        [Route("CreateRentalOptimisticApproach")]
        public IHttpActionResult CreateRentalOptimisticApproach(RentalDto rentalDto)
        {

            // let it throw an exception if customer is not found
            var customer = _dbContext.Customers.Single(c => c.Id == rentalDto.CustomerId);

            var movies = _dbContext.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();


            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("One or more movie is not avaliable for rent");
                }

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _dbContext.Rentals.Add(rental);
                movie.NumberAvailable--;
            }
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
