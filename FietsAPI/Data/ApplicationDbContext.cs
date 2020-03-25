using FietsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FietsAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Part> Parts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //Another way to seed the database
            builder.Entity<Part>().HasData(
                 new Part { Id = 1, Name = "Bottom Bracket", Description = "De Bottom Bracket is de motor van de Bike. Het Part zit tussen de twee pedalen en zorgt dat de pedalen goed draaien.", Functionality = Functionality.Aandrijving },
                 new Part { Id = 2, Name = "Crank Set", Description = "De crankset zal voor de meeste mensen bekend staan als de pedalen.", Functionality = Functionality.Aandrijving });


        }



    }
}
