using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    using System.Security.AccessControl;

    public class Movie
    {
        public int MovieID { get; set; }

        [Required]
        [Display (Name = " Name of Movie")]
        public string MovieName { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number of Copies")]
        public byte NumberOfCopies { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
    }
}