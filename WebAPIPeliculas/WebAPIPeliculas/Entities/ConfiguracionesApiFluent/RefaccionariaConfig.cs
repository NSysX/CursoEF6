using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPIPeliculas.Entities.ConfiguracionesApiFluent
{
    public class RefaccionariaConfig : IEntityTypeConfiguration<Refaccionaria>
    {
        public void Configure(EntityTypeBuilder<Refaccionaria> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Refaccionaria").HasComment("Lista de todas las Refaccionarias");

            builder.HasIndex(x => x.Nombre, "Ix_NoDupNombreRefa").IsUnique();

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nombre de la Refaccionaria");

            builder.Property(x => x.Ubicacion)
                .HasComment("La Ubicacion de la Refaccionaria (Longitud y Latitud)");
        }
    }
}
