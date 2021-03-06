using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.DTOs;
using vidly.Models;

namespace vidly.Controllers.API
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = ApplicationDbContext.Create();
        }

        // GET /api/Movies
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _dbContext.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.StartsWith(query));
            }
             
            var moviesDtos = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(moviesDtos);
        }

        // GET /api/Movies/{id}
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var newMovie = Mapper.Map<MovieDto, Movie>(movieDto);
            _dbContext.Movies.Add(newMovie);
            _dbContext.SaveChanges();

            return Created(new Uri($"{Request.RequestUri}/{newMovie.Id}"), newMovie);
        }

        // PUT /api/Movies/{id}
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            movieDto.DisableAutoMappingId();

            Mapper.Map(movieDto, movieInDb);
            _dbContext.SaveChanges();

            movieDto.Id = movieInDb.Id;

            return Ok(movieDto);
        }

        // DELETE /api/Movies/{id}
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }
            _dbContext.Movies.Remove(movieInDb);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
