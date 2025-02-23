using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstudiantes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EstudianteEntityDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Estudiantes_IDEstudiante",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IDEstudiante",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "IDEstudiante",
                table: "Usuarios",
                newName: "IDPrograma");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "IDPrograma",
                table: "Usuarios",
                newName: "IDEstudiante");

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    IDEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.IDEstudiante);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IDEstudiante",
                table: "Usuarios",
                column: "IDEstudiante",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Estudiantes_IDEstudiante",
                table: "Usuarios",
                column: "IDEstudiante",
                principalTable: "Estudiantes",
                principalColumn: "IDEstudiante",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
