﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]

        public string MembershipName { get; set; }
        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }
    }
}