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
    public class MoviesController : Controller
    {
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
            var movie = StaticData.Movies.Find(m => m.Id == Id);
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
            var movies = StaticData.Movies;
            var columns = new List<string>
            {
                "Movie"
            };
            var moviesTable = new TableViewModel<Movie>
            {
                Columns = columns,
                Rows = movies
            };
            return View(moviesTable);
        }
    }
}