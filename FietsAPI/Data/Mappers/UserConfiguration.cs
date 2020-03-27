using FietsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Data.Mappers
{
    public class UserConfiguration : IEntityTypeConfiguration<BUser>
    {
        public void Configure(EntityTypeBuilder<BUser> builder)
        {
            builder.ToTable("User");
            builder.HasKey(b => b.Email);
            builder.Property(b => b.FirstName).IsRequired().HasMaxLength(64);
            builder.Property(b => b.LastName).IsRequired().HasMaxLength(64);
            builder.Property(b => b.Email).IsRequired().HasMaxLength(64);
        }
    }
}
