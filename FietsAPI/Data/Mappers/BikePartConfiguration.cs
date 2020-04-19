using FietsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Data.Mappers
{
    public class BikePartConfiguration : IEntityTypeConfiguration<BikePart>
    {
        public void Configure(EntityTypeBuilder<BikePart> builder)
        {
            builder.ToTable("BikePart");
            builder.HasKey(b => new { b.BikeId, b.PartId });

            builder.HasOne(b => b.Part).WithMany(p => p.BikeParts).HasForeignKey(b => b.PartId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Bike).WithMany(b => b.Parts).HasForeignKey(b => b.BikeId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
