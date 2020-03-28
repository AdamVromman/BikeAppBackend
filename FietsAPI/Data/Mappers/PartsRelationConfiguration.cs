using FietsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Data.Mappers
{
    public class PartsRelationConfiguration : IEntityTypeConfiguration<PartsRelation>
    {
        public void Configure(EntityTypeBuilder<PartsRelation> builder)
        {
            builder.ToTable("PartsRelation");
            builder.HasKey(b => new { b.DomId, b.DepId });

            builder.HasOne(b => b.DependantPart).WithMany(b => b.DependantParts).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.DominantPart).WithMany(b => b.DominantParts).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
