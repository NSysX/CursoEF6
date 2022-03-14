using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPIPeliculas.Entities.ConfiguracionesApiFluent
{
    public class ConfiguracionPeliculaSalaCine : IEntityTypeConfiguration<PeliculaSalaCine>
    {
        public void Configure(EntityTypeBuilder<PeliculaSalaCine> builder)
        {
            builder.HasKey(x => new { x.IdPelicula, x.IdSalaCine });

            builder.ToTable("PeliculaSalaCine").HasComment("Relacion de las peliculas en las salas de cine");

            builder.HasIndex(x => new { x.IdPelicula, x.IdSalaCine }, "Ix_NoDuplicado").IsUnique();

            builder.Property(x => x.IdSalaCine)
                .IsRequired()
                .HasComment("El id de la tabla de Sala de Cine");

            builder.Property(x => x.IdPelicula)
                .IsRequired()
                .HasComment("El id de la tabla de Pelicula");

            // los foreingkey
            builder.HasOne(ps => ps.Pelicula)
                .WithMany(p => p.PeliculaSalaCines)
                .HasForeignKey(ps => ps.IdPelicula)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Fk_PeliculaSalaCine_Pelicula");

            builder.HasOne(ps => ps.SalaCine)
                .WithMany(s => s.PeliculaSalaCines)
                .HasForeignKey(ps => ps.IdSalaCine)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Fk_PeliculaSalaCine_SalaCine");
        }
    }
}