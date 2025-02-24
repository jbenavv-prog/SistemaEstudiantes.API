using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstudiantes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProgramaEntityAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IDPrograma",
                table: "Usuarios",
                column: "IDPrograma");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Programas_IDPrograma",
                table: "Usuarios",
                column: "IDPrograma",
                principalTable: "Programas",
                principalColumn: "IDPrograma",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Programas_IDPrograma",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IDPrograma",
                table: "Usuarios");
        }
    }
}
