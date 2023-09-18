using Database.EntityConfigurations;
using Database.Models;
using Microsoft.EntityFrameworkCore;

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
            builder.ApplyConfiguration(new SerieGenderConfiguration());
        }
        public DbSet<Genders> Genders { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<ProductionCompain> ProductionCompanies { get; set; }
        public DbSet<SerieGender> SerieGenders { get; set; }


    }
}
