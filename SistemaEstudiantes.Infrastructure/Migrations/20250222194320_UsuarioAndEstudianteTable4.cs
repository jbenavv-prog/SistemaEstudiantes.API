using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstudiantes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioAndEstudianteTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Estudiantes",
                newName: "IDEstudiante");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Estudiantes_IDEstudiante",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IDEstudiante",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "IDEstudiante",
                table: "Estudiantes",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }
    }
}
