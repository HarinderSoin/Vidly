using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    using System.Security.AccessControl;

    public class Movie
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
    }
}