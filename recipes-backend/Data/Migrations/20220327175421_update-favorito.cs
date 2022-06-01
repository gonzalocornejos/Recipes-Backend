using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipes_backend.Migrations
{
    public partial class updatefavorito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receta_Usuario_FavoritaId",
                table: "Receta");

            migrationBuilder.DropForeignKey(
                name: "FK_Receta_Usuario_RecetaId",
                table: "Receta");

            migrationBuilder.DropIndex(
                name: "IX_Receta_FavoritaId",
                table: "Receta");

            migrationBuilder.DropIndex(
                name: "IX_Receta_RecetaId",
                table: "Receta");

            migrationBuilder.DropColumn(
                name: "FavoritaId",
                table: "Receta");

            migrationBuilder.DropColumn(
                name: "RecetaId",
                table: "Receta");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Receta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receta_UsuarioId",
                table: "Receta",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receta_Usuario_UsuarioId",
                table: "Receta",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receta_Usuario_UsuarioId",
                table: "Receta");

            migrationBuilder.DropIndex(
                name: "IX_Receta_UsuarioId",
                table: "Receta");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Receta");

            migrationBuilder.AddColumn<int>(
                name: "FavoritaId",
                table: "Receta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecetaId",
                table: "Receta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receta_FavoritaId",
                table: "Receta",
                column: "FavoritaId");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_RecetaId",
                table: "Receta",
                column: "RecetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receta_Usuario_FavoritaId",
                table: "Receta",
                column: "FavoritaId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receta_Usuario_RecetaId",
                table: "Receta",
                column: "RecetaId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
