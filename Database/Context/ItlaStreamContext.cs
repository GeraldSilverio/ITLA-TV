using Database.EntityConfigurations;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Context
{
    public class ItlaStreamContext :DbContext
    {
        public ItlaStreamContext(DbContextOptions<ItlaStreamContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new GendersConfiguration());
            builder.ApplyConfiguration(new ProductionConfiguration());
            builder.ApplyConfiguration(new SeriesConfiguration());
        }
        public DbSet<Genders> Genders { get; set; }


    }
}
