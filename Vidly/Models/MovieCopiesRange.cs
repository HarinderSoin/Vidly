using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieCopiesRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie) validationContext.ObjectInstance;

            if(movie.NumberOfCopies >= Movie.MinCopies && movie.NumberOfCopies <= Movie.MaxCopies)
                return ValidationResult.Success;
            return new ValidationResult("Number of Copies must be between 1 and 20");
        }
    }
}