using FietsAPI.Data.Mappers;
using FietsAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FietsAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Part> Parts { get; set; }
        public DbSet<BUser> BUsers { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<PartsRelation> PartsRelations {get;set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PartConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new BikeConfiguration());
            builder.ApplyConfiguration(new PartsRelationConfiguration());
        }



    }
}
