using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipes_backend.Migrations
{
    public partial class contraseñausuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorita_Receta_RecetasId",
                table: "Favorita");

            migrationBuilder.RenameColumn(
                name: "RecetasId",
                table: "Favorita",
                newName: "RecetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorita_RecetasId",
                table: "Favorita",
                newName: "IX_Favorita_RecetaId");

            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "123");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorita_Receta_RecetaId",
                table: "Favorita",
                column: "RecetaId",
                principalTable: "Receta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorita_Receta_RecetaId",
                table: "Favorita");

            migrationBuilder.DropColumn(
                name: "Contraseña",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "RecetaId",
                table: "Favorita",
                newName: "RecetasId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorita_RecetaId",
                table: "Favorita",
                newName: "IX_Favorita_RecetasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorita_Receta_RecetasId",
                table: "Favorita",
                column: "RecetasId",
                principalTable: "Receta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
