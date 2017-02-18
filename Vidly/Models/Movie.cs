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
        public string MovieName { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public byte NumberOfCopies { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
    }
}