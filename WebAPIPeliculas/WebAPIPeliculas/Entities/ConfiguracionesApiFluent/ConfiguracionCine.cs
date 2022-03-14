using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPIPeliculas.Entities.ConfiguracionesApiFluent
{
    public class ConfiguracionCine : IEntityTypeConfiguration<Cine>
    {
        public void Configure(EntityTypeBuilder<Cine> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Cine").HasComment("Lista de los datos de los Cines");

            builder.HasIndex(x => x.Nombre,"Ix_NoDupNombre").IsUnique();

            builder.Property(x => x.Id).HasComment("Identificador consecutivo Unico");

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Nombre del Cine");

            //builder.Property(x => x.Precio)
            //    .IsRequired()
            //    //.HasColumnType("Numeric(14,4)")
            //    .HasPrecision(precision: 14, scale: 4)
            //    .HasComment("Precio de entrada de Cine");
        }
    }
}
