using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaEstudiantes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProfesoresSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Profesores",
                columns: new[] { "IDProfesor", "Nombre" },
                values: new object[,]
                {
                    { 1, "Carlos Gómez" },
                    { 2, "Ana Rodríguez" },
                    { 3, "Luis Fernández" },
                    { 4, "María López" },
                    { 5, "Javier Pérez" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "IDProfesor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "IDProfesor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "IDProfesor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "IDProfesor",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "IDProfesor",
                keyValue: 5);
        }
    }
}
