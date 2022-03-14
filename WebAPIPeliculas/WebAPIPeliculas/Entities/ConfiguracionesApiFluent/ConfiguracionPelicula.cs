using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPIPeliculas.Entities.ConfiguracionesApiFluent
{
    public class ConfiguracionPelicula : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Pelicula").HasComment("Listado de Peliculas");

            builder.HasIndex(x => x.Titulo, "IX_NoDupTitulo").IsUnique();

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Titulo de la Pelicula");

            builder.Property(x => x.EnCartelera).HasComment("Si esta en Cartelera");

            builder.Property(x => x.FechaEstreno)
                .HasColumnType("date")
                .HasComment("Fecha de Estreno");

            builder.Property(x => x.PosterURL)
                .IsRequired(true)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("Imagen del poster de la Pelicula");
        }
    }
}
