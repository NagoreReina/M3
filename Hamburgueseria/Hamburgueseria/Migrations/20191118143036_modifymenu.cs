using Microsoft.EntityFrameworkCore.Migrations;

namespace Hamburgueseria.Migrations
{
    public partial class modifymenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEntrante",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IdPostre",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IdPrincipal",
                table: "Menu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEntrante",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPostre",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPrincipal",
                table: "Menu",
                type: "int",
                nullable: true);
        }
    }
}
