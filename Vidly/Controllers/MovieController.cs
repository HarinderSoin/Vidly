using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    using Vidly.Models;

    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult MovieDetails(int id)
        {
            var movie = new Movie();
            movie = this.GetMovies().SingleOrDefault(x => x.MovieID == id)
            ;
            
            return Content("Still working on this");
        }

        private IEnumerable<Movie> GetMovies()
        {
            List<Movie> movie = new List<Movie>();
            movie.Add(new Movie() {MovieID = 1, MovieName = "Harry Potter"});
            movie.Add(new Movie() {MovieID = 2, MovieName = "Lord of the Rings"});
            return movie;
        }

        public ActionResult ListMovies()
        {
            var movies = this.GetMovies(); 
            return this.View("MoviesList", movies);
        }
    }
}