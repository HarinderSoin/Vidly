using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public int? MovieID { get; set; }

        [Required]
        [Display(Name = " Name of Movie")]
        public string MovieName { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        [Required]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number of Copies")]
        [MovieCopiesRange]
        [Required]
        public byte? NumberOfCopies { get; set; }

        [Required]
        [Display (Name = "Genres")]
        public byte? GenreId { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Title { get; set; }

        public MovieFormViewModel(Movie movie)
        {
            MovieID = movie.MovieID;
            MovieName = movie.MovieName;
            ReleaseDate = movie.ReleaseDate;
            DateAdded = movie.DateAdded;
            NumberOfCopies = movie.NumberOfCopies;
            GenreId = movie.GenreId; 
        }

        public MovieFormViewModel()
        {
            MovieID = 0; 
        }
    }
}