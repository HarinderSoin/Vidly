using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //Get/api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var moviesDTO = _context.Movies.ToList().Select(Mapper.Map<Movie, MoviesDTO>);
            return Ok(moviesDTO); 
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDTO moviesDto)
        {
            if (!ModelState.IsValid)
                BadRequest();
            var movie = Mapper.Map<MoviesDTO, Movie>(moviesDto);
        
            _context.Movies.Add(movie);
            _context.SaveChanges();
            moviesDto.MovieID = movie.MovieID;
            return Created(new Uri(Request.RequestUri + "/"+ movie.MovieID), moviesDto ); 
        }

        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieID == id);
            if (movie == null)
                BadRequest();

            return Ok(Mapper.Map<Movie, MoviesDTO>(movie)); 
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.MovieID == id);

            if (movieInDB == null)
                return BadRequest();

            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();
            return Ok(); 
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MoviesDTO moviesDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var movieInDB = _context.Movies.SingleOrDefault(m => m.MovieID == id);

            if (movieInDB == null)
                NotFound();

            var movie = Mapper.Map(moviesDto, movieInDB);

            _context.SaveChanges();
            return Ok(Mapper.Map(movieInDB, moviesDto)); 

        }
    }
}
