using Microsoft.EntityFrameworkCore;
using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.Infrastructure.Configurations;

namespace SistemaEstudiantes.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
        public AppDbContext() { }
        // Constructor con parámetros (usado en tiempo de ejecución)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EstudianteConfiguration());

            base.OnModelCreating(modelBuilder);

        }
    }
}
