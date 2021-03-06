﻿using System;
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
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        [Required]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number of Copies")]
        [MovieCopiesRange]
        [Required]
        public byte NumberOfCopies { get; set; }

        public Genre Genre { get; set; }

        [Display (Name = "Genre Type")]
        public byte GenreId { get; set; }

        public static  readonly int MinCopies = 1;
        public static readonly int MaxCopies = 20; 
    }
}