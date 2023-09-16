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
    public class SeriesConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.ToTable("Series");
            builder.HasKey(S => S.Id);
            builder.Property(S => S.Name).HasMaxLength(100);
            builder.HasIndex(S => S.Name).IsUnique();

           
        }
    }
}
