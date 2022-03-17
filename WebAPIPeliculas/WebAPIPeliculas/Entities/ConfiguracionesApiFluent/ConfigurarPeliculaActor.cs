using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPIPeliculas.Entities.ConfiguracionesApiFluent
{

    public class ConfigurarPeliculaActor : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            builder.HasKey(x => new { x.IdPelicula, x.IdActor });

            builder.ToTable("PeliculaActor").HasComment("Relacion de actores y peliculas");

            builder.HasIndex(x => new { x.IdActor, x.IdPelicula }, "Ix_NoDuplicado").IsUnique();

            builder.Property(x => x.IdActor)
                .IsRequired()
                .HasComment("Id consecutivo de la tabla de actores");

            builder.Property(x => x.IdPelicula)
                .IsRequired()
                .HasComment("Id consecutivo de la tabla de peliculas");

            builder.Property(x => x.Personaje)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre del personaje del actor");

            builder.Property(x => x.Orden)
                .IsRequired()
                .HasComment("Orden de importancia en la pelicula");

            builder.HasOne(pa => pa.Pelicula) // tiene un campo de objeto Pelicula
                .WithMany(p => p.PeliculaActores) // donde hace el enlace 
                .HasForeignKey(pa => pa.IdPelicula) // y esta es la llave
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Fk_PeliculaActor_Pelicula");

            builder.HasOne(pa => pa.Actor) // Propiedad virtual de navegacion entidad PeliculaActor
                .WithMany(a => a.Peliculas) // propiedad en PeliculaActor lista de Actores  
                .HasForeignKey(pa => pa.IdActor) // y esta es la llave de la relacion de la tabla peliculaActor
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Fk_PeliculaActor_Actor");

        }
    }
}
