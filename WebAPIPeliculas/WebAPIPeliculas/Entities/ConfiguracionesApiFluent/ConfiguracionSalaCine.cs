using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPIPeliculas.Enum;

namespace WebAPIPeliculas.Entities.ConfiguracionesApiFluent
{
    public class ConfiguracionSalaCine : IEntityTypeConfiguration<SalaCine>
    {
        public void Configure(EntityTypeBuilder<SalaCine> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("SalaCine").HasComment("Salas de Cine");

            builder.HasIndex(x => new { x.CineId, x.Precio },"Ix_NoDuplicado").IsUnique();

            builder.Property(x => x.TipoSalaCine)
                .IsRequired()
                .HasComment("Tipo de sala de cine")
                .HasDefaultValue(TipoSalaCine.DosDimensiones);

            builder.Property(x => x.Precio)
                .IsRequired()
                .HasPrecision(precision: 10, scale: 2)
                .HasComment("Precio de la entrada a la Sala de Cine");

            builder.Property(x => x.CineId)
                .IsRequired()
                .HasComment("el Id del cine al que pertenece la sala");

            builder.HasOne(x => x.Cine)
                .WithMany(x => x.SalasCine)
                .HasForeignKey(x => x.CineId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Fk_SalaCine_Cine");

        }
    }
}
