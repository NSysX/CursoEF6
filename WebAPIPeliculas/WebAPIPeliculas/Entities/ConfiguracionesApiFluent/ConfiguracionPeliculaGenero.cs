using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPIPeliculas.Entities.ConfiguracionesApiFluent
{
    public class ConfiguracionPeliculaGenero : IEntityTypeConfiguration<PeliculaGenero>
    {
        public void Configure(EntityTypeBuilder<PeliculaGenero> builder)
        {
            builder.HasKey(x => new { x.IdPelicula, x.IdGenero });

            builder.ToTable("PeliculaGenero").HasComment("Relacion de muchos a muchos entre genero y pelicula");

            builder.HasIndex(x => new { x.IdPelicula, x.IdGenero }, "Ix_NoDuplicado").IsUnique();

            builder.Property(x => x.IdPelicula)
                .HasComment("El Id consecutivo de la tabla de Pelicula");

            builder.Property(x => x.IdGenero)
                .HasComment("El Id consecutivo de la tabla de generos");

            builder.HasOne(pg => pg.Pelicula)
                .WithMany(p => p.PeliculaGenero)
                .HasForeignKey(pg => pg.IdPelicula)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_PeliculaGenero_Pelicula");

            builder.HasOne(pg => pg.Genero)
                .WithMany(g => g.PeliculaGenero)
                .HasForeignKey(pg => pg.IdGenero)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Fk_PeliculaGenero_Genero");

        }
    }
}
