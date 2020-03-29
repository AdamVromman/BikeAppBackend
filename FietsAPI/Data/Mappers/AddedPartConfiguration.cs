using FietsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Data.Mappers
{
    public class AddedPartConfiguration : IEntityTypeConfiguration<AddedPart>
    {
        public void Configure(EntityTypeBuilder<AddedPart> builder)
        {
            builder.ToTable("AddedPart");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(64);
            builder.Property(b => b.Price);
            builder.Property(b => b.Brand).IsRequired(false);

            builder.HasOne(b => b.Part);
            builder.HasOne(b => b.BUser);
        }
    }
}
