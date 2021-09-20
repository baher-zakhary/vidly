using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.Static_data;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {      
        
        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = ApplicationDbContext.Create();
        }
        public ActionResult Random()
        {
            var RandomMovieViewModel = new RandomMovieViewModel();
            RandomMovieViewModel.Movie = new Movie { Name = "Random Movie" };
            RandomMovieViewModel.Customers = new List<Customer> {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" },
                new Customer { Name = "Customer 3" }
            };
            return View(RandomMovieViewModel);
        }

        public ActionResult Details(int Id)
        {
            var movie = _dbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            if (movie != null)
            {
                return View(movie);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _dbContext.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
    }
}