using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaEstudiantes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProfesoresSeedData6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Creditos",
                table: "Materias",
                type: "int",
                nullable: false,
                defaultValue: 3,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "IDMateria", "Creditos", "IDProfesor", "Nombre" },
                values: new object[,]
                {
                    { 1, 3, 1, "Programación I" },
                    { 2, 3, 1, "Programación II" },
                    { 3, 3, 2, "Bases de Datos" },
                    { 4, 3, 2, "Sistemas Operativos" },
                    { 5, 3, 3, "Redes de Computadoras" },
                    { 6, 3, 3, "Seguridad Informática" },
                    { 7, 3, 4, "Arquitectura de Computadoras" },
                    { 8, 3, 4, "Inteligencia Artificial" },
                    { 9, 3, 5, "Desarrollo Web" },
                    { 10, 3, 5, "Ingeniería de Software" }
                });

            migrationBuilder.InsertData(
                table: "Programas",
                columns: new[] { "IDPrograma", "Nombre" },
                values: new object[] { 1, "Ingeniería de Sistemas" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "IDMateria",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "IDMateria",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "IDMateria",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "IDMateria",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "IDMateria",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "IDMateria",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "IDMateria",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "IDMateria",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "IDMateria",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "IDMateria",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Programas",
                keyColumn: "IDPrograma",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Creditos",
                table: "Materias",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 3);
        }
    }
}
