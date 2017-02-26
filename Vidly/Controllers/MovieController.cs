using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;

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
            var viewModel = new MovieFormViewModel (movieDetail)
            {
                Title = "Edit Movie",
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
       
        public ActionResult ListMovies()
        {
            var movie = this._context.Movies.Include(m => m.Genre).ToList();
            return View("MoviesList", movie);
        }

        public ActionResult NewMovie(int? id)
        {
            var movie = new Movie();
            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
       
            };

           viewModel.Title = "New Movie";

           
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()

                };
                return View("MovieForm", viewModel);
            }
     
            if (movie.MovieID == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var MovieInDB = _context.Movies.Single(m => m.MovieID == movie.MovieID);
                MovieInDB.MovieName = movie.MovieName;
                MovieInDB.DateAdded = movie.DateAdded;
                MovieInDB.ReleaseDate = movie.ReleaseDate;
                MovieInDB.NumberOfCopies = movie.NumberOfCopies;
                MovieInDB.GenreId = movie.GenreId;
            }
            
                _context.SaveChanges();
            
            return RedirectToAction("ListMovies", "movie");
        }
    }
}