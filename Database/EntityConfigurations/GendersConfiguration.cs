using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.EntityConfigurations
{
    public class GendersConfiguration : IEntityTypeConfiguration<Genders>
    {
        public void Configure(EntityTypeBuilder<Genders> builder)
        {
            builder.ToTable("Genders");
            builder.HasKey(G => G.Id);
            builder.Property(G => G.Name).HasMaxLength(100);
            builder.HasIndex(G => G.Name).IsUnique();
        }
    }
}
