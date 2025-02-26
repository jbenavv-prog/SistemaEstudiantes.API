using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstudiantes.Domain.Entities;

namespace SistemaEstudiantes.Infrastructure.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.Property(u => u.Nombre)
               .IsRequired()
               .HasMaxLength(100);

            builder.HasIndex(u => u.Email)
                .IsUnique();
       
            builder.HasKey(u => u.IDUsuario);

            builder.HasOne(u => u.Programa)
                   .WithMany(p => p.Usuarios)
                   .HasForeignKey(m => m.IDPrograma);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Contrasena)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.FechaRegistro)
                .IsRequired();
        }
    }
}
