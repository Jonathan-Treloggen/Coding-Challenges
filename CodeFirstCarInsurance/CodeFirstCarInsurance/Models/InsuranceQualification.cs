using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstCarInsurance.Models
{
    public class InsuranceQualification
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool DUI { get; set; }
        public int SpeedingTickets { get; set; }
    }
}