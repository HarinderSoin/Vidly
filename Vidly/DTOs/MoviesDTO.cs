using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class MoviesDTO
    {
        public int MovieID { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public byte NumberOfCopies { get; set; }

        public byte GenreId { get; set; }

        public static readonly int MinCopies = 1;
        public static readonly int MaxCopies = 20;
    }
}