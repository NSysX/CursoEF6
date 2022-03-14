using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPIPeliculas.Entities.ConfiguracionesApiFluent
{
    public class ConfiguracionGenero : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(g => g.Id);

            builder.ToTable("Genero").HasComment("Generos de Peliculas");
            
            builder.HasIndex(g => g.Nombre, "IX_NoDuplicadoNombre").IsUnique();
            
            builder.Property(g => g.Nombre)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Nombre del Genero de Pelicula");
        }
    }
}
