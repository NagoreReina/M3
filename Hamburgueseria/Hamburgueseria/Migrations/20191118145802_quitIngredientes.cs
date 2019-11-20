using Microsoft.EntityFrameworkCore.Migrations;

namespace Hamburgueseria.Migrations
{
    public partial class quitIngredientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.AddColumn<string>(
                name: "Ingredientes",
                table: "Principales",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredientes",
                table: "Postres",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredientes",
                table: "Entrantes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ingredientes",
                table: "Principales");

            migrationBuilder.DropColumn(
                name: "Ingredientes",
                table: "Postres");

            migrationBuilder.DropColumn(
                name: "Ingredientes",
                table: "Entrantes");

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrantesId = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    PostresId = table.Column<int>(type: "int", nullable: true),
                    PrincipalesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Entrantes_EntrantesId",
                        column: x => x.EntrantesId,
                        principalTable: "Entrantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Postres_PostresId",
                        column: x => x.PostresId,
                        principalTable: "Postres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Principales_PrincipalesId",
                        column: x => x.PrincipalesId,
                        principalTable: "Principales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_EntrantesId",
                table: "Ingredientes",
                column: "EntrantesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_PostresId",
                table: "Ingredientes",
                column: "PostresId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_PrincipalesId",
                table: "Ingredientes",
                column: "PrincipalesId");
        }
    }
}
