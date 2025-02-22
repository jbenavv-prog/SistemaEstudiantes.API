using Microsoft.EntityFrameworkCore;
using SistemaEstudiantes.Domain.Entities;

namespace SistemaEstudiantes.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public AppDbContext() { }
        // Constructor con parámetros (usado en tiempo de ejecución)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>(entity => {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            });
        }
    }
}
