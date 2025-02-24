using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstudiantes.Domain.Entities;

namespace SistemaEstudiantes.Infrastructure.Configurations
{
    public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
    {
        public void Configure(EntityTypeBuilder<Profesor> builder)
        {
            builder.ToTable("Profesores");

            builder.HasKey(p => p.IDProfesor);

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            // **SEED DATA: Insertar 5 profesores**
            builder.HasData(
                new Profesor { IDProfesor = 1, Nombre = "Carlos Gómez" },
                new Profesor { IDProfesor = 2, Nombre = "Ana Rodríguez" },
                new Profesor { IDProfesor = 3, Nombre = "Luis Fernández" },
                new Profesor { IDProfesor = 4, Nombre = "María López" },
                new Profesor { IDProfesor = 5, Nombre = "Javier Pérez" }
            );
        }
    }
}
