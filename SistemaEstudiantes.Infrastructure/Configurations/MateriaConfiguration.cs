using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstudiantes.Domain.Entities;

namespace SistemaEstudiantes.Infrastructure.Configurations
{
    public class MateriaConfiguration : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.ToTable("Materias");
            builder.HasKey(m => m.IDMateria);

            builder.HasOne(m => m.Profesor)
                   .WithMany(p => p.Materias)
                   .HasForeignKey(m => m.IDProfesor)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.Nombre)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.Creditos)
                   .IsRequired()
                   .HasDefaultValue(3);

            // **SEED DATA: 10 materias de Ingeniería en Sistemas (2 por profesor)**
            builder.HasData(
                new Materia { IDMateria = 1, Nombre = "Programación I", IDProfesor = 1, Creditos = 3 },
                new Materia { IDMateria = 2, Nombre = "Programación II", IDProfesor = 1, Creditos = 3 },

                new Materia { IDMateria = 3, Nombre = "Bases de Datos", IDProfesor = 2, Creditos = 3 },
                new Materia { IDMateria = 4, Nombre = "Sistemas Operativos", IDProfesor = 2, Creditos = 3 },

                new Materia { IDMateria = 5, Nombre = "Redes de Computadoras", IDProfesor = 3 , Creditos = 3 },
                new Materia { IDMateria = 6, Nombre = "Seguridad Informática", IDProfesor = 3 , Creditos = 3 },

                new Materia { IDMateria = 7, Nombre = "Arquitectura de Computadoras", IDProfesor = 4 , Creditos = 3 },
                new Materia { IDMateria = 8, Nombre = "Inteligencia Artificial", IDProfesor = 4 , Creditos = 3 },

                new Materia { IDMateria = 9, Nombre = "Desarrollo Web", IDProfesor = 5 , Creditos = 3 },
                new Materia { IDMateria = 10, Nombre = "Ingeniería de Software", IDProfesor = 5 , Creditos = 3 }
            );
        }
    }
}
