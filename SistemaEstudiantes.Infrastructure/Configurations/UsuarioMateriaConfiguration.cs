using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstudiantes.Domain.Entities;

namespace SistemaEstudiantes.Infrastructure.Configurations
{
    public class UsuarioMateriaConfiguration : IEntityTypeConfiguration<UsuarioMateria>
    {
        public void Configure(EntityTypeBuilder<UsuarioMateria> builder)
        {
            builder.ToTable("UsuarioMaterias");

            builder.HasKey(u => u.IDUsuarioMateria);

            // ID ESTUDIANTE FK
            builder.HasOne(u => u.Usuario) // Un usuario tiene muchas materias
                .WithMany(p => p.UsuarioMaterias) // Un estudiante puede inscribirse en muchas materias
                .HasForeignKey(u => u.IDUsuario) // Clave foránea en UsuarioMateria
                .IsRequired();

            // ID MATERIA FK
            builder.HasOne(u => u.Materia) // Una materia puede tener muchos estudiantes inscritos
                .WithMany(m => m.UsuarioMaterias) // Una materia está en muchas inscripciones
                .HasForeignKey(u => u.IDMateria) // Clave foránea en UsuarioMateria
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
