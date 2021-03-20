using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstCarInsurance.Models
{
    public class CarInsuranceDBContext : DbContext
    {
        public CarInsuranceDBContext() : base("CodeFirstConnection")
        {

        }

        public DbSet<InsuranceQualification> InsuranceQualification { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}