using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPIPeliculas.Entities.ConfiguracionesApiFluent
{
    public class ConfiguracionCineOferta : IEntityTypeConfiguration<CineOferta>
    {
        public void Configure(EntityTypeBuilder<CineOferta> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("CineOferta").HasComment("Ofertas de descuento del cine");

            builder.HasIndex(x => new { x.CineId, x.FechaInicio, x.FechaFin }, "Ix_NoDuplicado").IsUnique();

            builder.Property(x => x.FechaInicio)
                .IsRequired(true)
                .HasColumnType("date")
                .HasComment("Fecha de Inicio de la Oferta");

            builder.Property(x => x.FechaFin)
                .IsRequired(true)
                .HasColumnType("date")
                .HasComment("Fecha de Fin de la Oferta");

            builder.Property(x => x.PorcentajeDescuento)
                .IsRequired(true)
                .HasPrecision(precision: 5, scale: 2);
        }
    }
}
