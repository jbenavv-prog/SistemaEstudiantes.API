using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstudiantes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AllEntitiesConf : Migration
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
                name: "Materias",
                columns: table => new
                {
                    IDMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDProfesor = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Creditos = table.Column<int>(type: "int", nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioMaterias");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
