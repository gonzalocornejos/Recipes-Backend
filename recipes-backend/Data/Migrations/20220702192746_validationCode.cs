using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipes_backend.Data.Migrations
{
    public partial class validationCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoValidacion",
                table: "Usuario",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoValidacion",
                table: "Usuario");
        }
    }
}
