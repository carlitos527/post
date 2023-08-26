using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configurations
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Publicacion", "dbo");

            builder.HasKey(x => x.Id)
                .HasName("PK_Publicacion");

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(x => x.Title)
                .HasColumnName("Titulo");

            builder.Property(x => x.Body)
                .HasColumnName("Cuerpo");

            builder.Property(x => x.Type)
                .HasColumnName("Tipo");

            builder.Property(x => x.Category)
                .HasColumnName("Categoria");

            builder.Property(x => x.CustomerId)
                .IsRequired()
                .HasColumnName("IdCliente");

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Publicacion_IdCliente");


        }
    }
}
