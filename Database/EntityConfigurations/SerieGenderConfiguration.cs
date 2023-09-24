using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EntityConfigurations
{
    public class SerieGenderConfiguration : IEntityTypeConfiguration<SerieGender>
    {
        public void Configure(EntityTypeBuilder<SerieGender> builder)
        {
            builder.ToTable("SeriesGenders");
            builder.HasKey(SG => new { SG.IdSerie, SG.IdGender });

            /*Creando relacion muchos a muchos,dada porque
             * un serie puede tener muchos generos y un genero
             * puede tener muchas series*/

            builder.HasOne(SG => SG.Serie)
            .WithMany(S => S.SerieGender)
            .HasForeignKey(SG => SG.IdSerie)
            .OnDelete(DeleteBehavior.ClientCascade);

             builder.HasOne(SG => SG.Gender)
            .WithMany(S => S.SerieGender)
            .HasForeignKey(SG => SG.IdGender)
            .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
