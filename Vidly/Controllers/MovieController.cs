using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    using Vidly.Models;

    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
        // GET: Movie

        public ActionResult MovieDetails(int id)
        {
            var movieDetail = new Movie();
            movieDetail= this._context.Movies.Include(m => m.Genre).SingleOrDefault(x => x.MovieID == id);
            return View("MovieDetail", movieDetail);
        }
        /*
        private IEnumerable<Movie> GetMovies()
        {
            List<Movie> movie = new List<Movie>();
            movie.Add(new Movie() {MovieID = 1, MovieName = "Harry Potter"});
            movie.Add(new Movie() {MovieID = 2, MovieName = "Lord of the Rings"});
            return movie;
        }
        */

        public ActionResult ListMovies()
        {
            var movie = this._context.Movies.Include(m => m.Genre).ToList();
            return View("MoviesList", movie);
        }
    }
}