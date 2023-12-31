﻿using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.EntityConfigurations
{
    public class ProductionConfiguration : IEntityTypeConfiguration<ProductionCompain>
    {
        public void Configure(EntityTypeBuilder<ProductionCompain> builder)
        {
            builder.ToTable("ProductionCompain");
            builder.HasKey(P => P.Id);
            builder.Property(P => P.Name).HasMaxLength(100);
            builder.HasIndex(P => P.Name).IsUnique();

            /*Creando la relacion 1 a muchos, ya que una productora puede 
             * pertenecer a muchas series pero una serie solo pertenece 
             * a una sola productora.*/
            builder.HasMany(P => P.Series)
            .WithOne(S => S.ProductionCompain)
            .HasForeignKey(S => S.IdProduction)
            .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
