using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.AccessControl;

    public class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; } 
        public byte MembershipTypeId { get; set; }

        
    }
}