using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstudiantes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TestDataAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDPrograma",
                table: "Estudiantes");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IDUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEstudiante = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IDUsuario);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "IDPrograma",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
