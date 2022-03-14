using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPIPeliculas.Entities.ConfiguracionesApiFluent
{
    public class ConfiguracionActor : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.ToTable("Actor").HasComment("Actores");

            builder.HasIndex(x => x.Nombre, "Ix_NoDuplicadoNombre").IsUnique();

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Nombre del Actor");

            builder.Property(x => x.FechaNacimiento)
                .HasColumnType("date");
        }
    }
}
