﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter Customer's name!")]
        [StringLength(255)]
        public string CustomerName { get; set; }


        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}