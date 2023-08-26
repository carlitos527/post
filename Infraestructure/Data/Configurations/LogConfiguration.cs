using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configurations
{
    internal class LogConfiguration : IEntityTypeConfiguration<Logs>
    {
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder.ToTable("Registro", "dbo");

            builder.HasKey(x => x.Id)
                .HasName("PK_Registro");

            builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("Id");

            builder.Property(x => x.Message)
                .HasColumnName("Mensaje");

            builder.Property(x => x.MessageTemplate)
                .HasColumnName("ModeloMensaje");

            builder.Property(x => x.Level)
                .HasColumnName("Nivel");

            builder.Property(x => x.TimeStamp)
                .HasColumnName("Fecha");

            builder.Property(x => x.Exception)
               .HasColumnName("Excepcion");

            builder.Property(x => x.Properties)
                .HasColumnName("Propiedad");
        }
    }
}
