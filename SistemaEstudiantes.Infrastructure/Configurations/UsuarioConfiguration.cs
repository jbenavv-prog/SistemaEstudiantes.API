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

            builder.HasIndex(u => u.Email)
                .IsUnique();
            // Clave primaria
            builder.HasKey(u => u.IDUsuario);

            // Relación Uno a Uno con Estudiante
            /*builder.HasOne(u => u.Estudiante)
               .WithOne(e => e.Usuario)
               .HasForeignKey<Usuario>(u => u.IDEstudiante)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);*/
            builder.Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Contrasena)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.FechaRegistro)
                .IsRequired();

            builder.Property(u => u.IDPrograma);
        }
    }
}
