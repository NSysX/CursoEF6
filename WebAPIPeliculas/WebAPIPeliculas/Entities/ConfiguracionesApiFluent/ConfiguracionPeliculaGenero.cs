using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPIPeliculas.Entities.ConfiguracionesApiFluent
{
    public class ConfiguracionPeliculaGenero : IEntityTypeConfiguration<PeliculaGenero>
    {
        public void Configure(EntityTypeBuilder<PeliculaGenero> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("PeliculaGenero").HasComment("Relacion de muchos a muchos entre genero y pelicula");

            builder.HasIndex(x => new { x.IdPelicula, x.IdGenero }, "Ix_NoDuplicado").IsUnique();

            builder.Property(x => x.IdPelicula)
                .HasComment("El Id consecutivo de la tabla de Pelicula");

            builder.Property(x => x.IdGenero)
                .HasComment("El Id consecutivo de la tabla de generos");

            builder.HasOne(pg => pg.Pelicula)
                .WithMany(p => p.Generos)
                .HasForeignKey(pg => pg.IdPelicula)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Fk_GeneroPelicula_Pelicula");

            builder.HasOne(pg => pg.Genero)
                .WithMany(g => g.Peliculas)
                .HasForeignKey(pg => pg.IdGenero)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Fk_GeneroPelicula_Genero");

        }
    }
}
