using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstudiantes.Domain.Entities;

namespace SistemaEstudiantes.Infrastructure.Configurations
{
    public class EstudianteConfiguration : IEntityTypeConfiguration<Estudiante>
    {
        public void Configure(EntityTypeBuilder<Estudiante> builder)
        {
            builder.ToTable("Estudiantes");

            // Clave primaria
            builder.HasKey(e => e.IDEstudiante);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
