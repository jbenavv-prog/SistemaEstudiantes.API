using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SistemaEstudiantes.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "SistemaEstudiantes.API");
            // Configurar la configuración desde appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(basePath) // Establecer la ruta base
                .AddJsonFile("appsettings.json") // Agregar el archivo de configuración JSON
                .Build();

            // Configurar el DbContextOptionsBuilder
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            // Crear una instancia de AppDbContext
            return new AppDbContext(builder.Options);
        }
    }
}