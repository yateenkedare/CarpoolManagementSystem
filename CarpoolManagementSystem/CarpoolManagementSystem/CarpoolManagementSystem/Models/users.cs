namespace LoginSignup.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class users : DbContext
    {
        public users()
            : base("name=users")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
