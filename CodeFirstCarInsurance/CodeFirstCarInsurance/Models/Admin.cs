﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstCarInsurance.Models
{
    public class Admin
    {
        [Key]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

    }
}