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

        public ActionResult Edit(int Id)
        {
            var movie = _dbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            if (movie != null)
            {
                var movieFormViewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _dbContext.Genres.ToList()
                };
                return View("MovieForm", movieFormViewModel);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Movies
        public ActionResult Index()
        {
            // User property of our controller gives us access to the logged in user
            if (User.IsInRole("CanManageMovies"))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");
            }
            //var movies = _dbContext.Movies.Include(m => m.Genre).ToList();
            //return View(movies);
        }

        public ActionResult New()
        {
            var movieFormViewModel = new MovieFormViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };
            return View("MovieForm", movieFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var movieToEdit = _dbContext.Movies.Single(m => m.Id == movie.Id);
                movieToEdit.Name = movie.Name;
                movieToEdit.ReleaseDate = movie.ReleaseDate;
                movieToEdit.GenreId = movie.GenreId;
                movieToEdit.NumberInStock = movie.NumberInStock;
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}