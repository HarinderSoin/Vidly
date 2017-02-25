using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Serialization;

namespace Vidly.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.AccessControl;

    public class Customer
    {
        
        public int CustomerID { get; set; }

        [Display (Name = "Date Of Birth")]
        [DataType(DataType.Date,ErrorMessage = "Please enter date in the MM/DD/YYYY format!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter Customer's name!")]
        [StringLength(255)]
        [Display (Name = "Customer Name")]
        public string CustomerName { get; set; }

        
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display (Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        
    }
}