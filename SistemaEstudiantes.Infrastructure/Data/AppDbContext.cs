using Microsoft.EntityFrameworkCore;
using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.Infrastructure.Configurations;

namespace SistemaEstudiantes.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<UsuarioMateria> UsuarioMaterias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Programa> Programas { get; set; }
        
        public AppDbContext() { }
        // Constructor con parámetros (usado en tiempo de ejecución)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfesorConfiguration());
            modelBuilder.ApplyConfiguration(new MateriaConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramaConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioMateriaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
