using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipes_backend.Migrations
{
    public partial class updatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredienteReceta");

            migrationBuilder.CreateTable(
                name: "Favorita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RecetasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorita_Receta_RecetasId",
                        column: x => x.RecetasId,
                        principalTable: "Receta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favorita_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorita_RecetasId",
                table: "Favorita",
                column: "RecetasId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorita_UsuarioId",
                table: "Favorita",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorita");

            migrationBuilder.CreateTable(
                name: "IngredienteReceta",
                columns: table => new
                {
                    IngredientesId = table.Column<int>(type: "int", nullable: false),
                    RecetasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteReceta", x => new { x.IngredientesId, x.RecetasId });
                    table.ForeignKey(
                        name: "FK_IngredienteReceta_Ingrediente_IngredientesId",
                        column: x => x.IngredientesId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredienteReceta_Receta_RecetasId",
                        column: x => x.RecetasId,
                        principalTable: "Receta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteReceta_RecetasId",
                table: "IngredienteReceta",
                column: "RecetasId");
        }
    }
}
