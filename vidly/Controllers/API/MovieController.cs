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
    public class MovieController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public MovieController()
        {
            _dbContext = ApplicationDbContext.Create();
        }

        // GET /api/Movies
        public IHttpActionResult GetMovies()
        {
            return Ok(_dbContext.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        // GET /api/Movie/{id}
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/Movie
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

            movieDto.Id = newMovie.Id;

            return Created(new Uri($"{Request.RequestUri}/{newMovie.Id}"), movieDto);
        }

        // PUT /api/Movie/{id}
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == movieDto.Id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movieInDb);
            movieDto.Id = movieInDb.Id;

            _dbContext.SaveChanges();

            return Ok(movieDto);
        }

        // DELETE /api/Movie/{id}
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
