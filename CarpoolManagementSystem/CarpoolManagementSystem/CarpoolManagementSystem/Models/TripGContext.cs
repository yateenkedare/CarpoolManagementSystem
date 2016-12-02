using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LoginSignup.Models
{
    public class TripGContext:DbContext
    {
        public TripGContext()
            : base("name=TripGContext")
        {
        }
        public DbSet<TripGroup> x { get; set; }
    }
}