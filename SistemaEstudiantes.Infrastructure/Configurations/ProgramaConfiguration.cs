using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstudiantes.Domain.Entities;

namespace SistemaEstudiantes.Infrastructure.Configurations
{
    public class ProgramaConfiguration : IEntityTypeConfiguration<Programa>
    {
        public void Configure(EntityTypeBuilder<Programa> builder)
        {
            builder.ToTable("Programas");

            builder.HasKey(p => p.IDPrograma);

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            // **SEED DATA: Insertar 1 programa**
            builder.HasData(
                        new Programa { IDPrograma = 1, Nombre = "Ingeniería de Sistemas" }
                    );
        }

    }

   
}
