namespace LoginSignup.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TripSam : DbContext
    {
        public TripSam()
            : base("name=TripSam")
        {
        }

        public virtual DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>()
                .Property(e => e.source)
                .IsUnicode(false);

            modelBuilder.Entity<Trip>()
                .Property(e => e.destination)
                .IsUnicode(false);

            modelBuilder.Entity<Trip>()
                .Property(e => e.estimated_cost)
                .HasPrecision(8, 2);
        }
    }
}
