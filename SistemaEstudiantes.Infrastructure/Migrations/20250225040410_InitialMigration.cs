using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaEstudiantes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    IDProfesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.IDProfesor);
                });

            migrationBuilder.CreateTable(
                name: "Programas",
                columns: table => new
                {
                    IDPrograma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programas", x => x.IDPrograma);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    IDMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDProfesor = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Creditos = table.Column<int>(type: "int", nullable: false, defaultValue: 3)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.IDMateria);
                    table.ForeignKey(
                        name: "FK_Materias_Profesores_IDProfesor",
                        column: x => x.IDProfesor,
                        principalTable: "Profesores",
                        principalColumn: "IDProfesor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IDUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPrograma = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IDUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Programas_IDPrograma",
                        column: x => x.IDPrograma,
                        principalTable: "Programas",
                        principalColumn: "IDPrograma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioMaterias",
                columns: table => new
                {
                    IDUsuarioMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUsuario = table.Column<int>(type: "int", nullable: false),
                    IDMateria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioMaterias", x => x.IDUsuarioMateria);
                    table.ForeignKey(
                        name: "FK_UsuarioMaterias_Materias_IDMateria",
                        column: x => x.IDMateria,
                        principalTable: "Materias",
                        principalColumn: "IDMateria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioMaterias_Usuarios_IDUsuario",
                        column: x => x.IDUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Programas",
                columns: new[] { "IDPrograma", "Nombre" },
                values: new object[] { 1, "Ingeniería de Sistemas" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Materias_IDProfesor",
                table: "Materias",
                column: "IDProfesor");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioMaterias_IDMateria",
                table: "UsuarioMaterias",
                column: "IDMateria");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioMaterias_IDUsuario",
                table: "UsuarioMaterias",
                column: "IDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IDPrograma",
                table: "Usuarios",
                column: "IDPrograma");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioMaterias");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Programas");
        }
    }
}
