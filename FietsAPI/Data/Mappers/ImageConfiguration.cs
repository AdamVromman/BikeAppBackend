using FietsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Data.Mappers
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.ImageData);
            builder.HasOne(b => b.Part).WithOne(a => a.Image);
        }
    }
}
