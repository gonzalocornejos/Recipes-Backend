using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipes_backend.Data.Migrations
{
    public partial class tipoPlatoManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoPlato_Receta_RecetaId",
                table: "TipoPlato");

            migrationBuilder.DropIndex(
                name: "IX_TipoPlato_RecetaId",
                table: "TipoPlato");

            migrationBuilder.DropColumn(
                name: "RecetaId",
                table: "TipoPlato");

            migrationBuilder.CreateTable(
                name: "RecetaTipoPlato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecetaId = table.Column<int>(type: "int", nullable: false),
                    TipoPlatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaTipoPlato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecetaTipoPlato_Receta_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Receta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetaTipoPlato_TipoPlato_TipoPlatoId",
                        column: x => x.TipoPlatoId,
                        principalTable: "TipoPlato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecetaTipoPlato_RecetaId",
                table: "RecetaTipoPlato",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaTipoPlato_TipoPlatoId",
                table: "RecetaTipoPlato",
                column: "TipoPlatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecetaTipoPlato");

            migrationBuilder.AddColumn<int>(
                name: "RecetaId",
                table: "TipoPlato",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoPlato_RecetaId",
                table: "TipoPlato",
                column: "RecetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoPlato_Receta_RecetaId",
                table: "TipoPlato",
                column: "RecetaId",
                principalTable: "Receta",
                principalColumn: "Id");
        }
    }
}
