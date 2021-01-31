using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace HospitalFind88.Models
{
    public class HospitalsContext : DbContext
    {
        public DbSet<Hospitals> hospitals { get; set; }

        public HospitalsContext() : base("DefaultConnection") {}

        public static HospitalsContext Create()
        {
            return new HospitalsContext();
        }
    }
}