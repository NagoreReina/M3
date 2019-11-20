using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hamburgueseria.Migrations
{
    public partial class createTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 25, nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Postres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 25, nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Principales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 25, nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 25, nullable: true),
                    EntrantesId = table.Column<int>(nullable: true),
                    PostresId = table.Column<int>(nullable: true),
                    PrincipalesId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    IdPrincipal = table.Column<int>(nullable: true),
                    PrincipalId = table.Column<int>(nullable: true),
                    IdEntrante = table.Column<int>(nullable: true),
                    EntranteId = table.Column<int>(nullable: true),
                    IdPostre = table.Column<int>(nullable: true),
                    PostreId = table.Column<int>(nullable: true),
                    Precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Entrantes_EntranteId",
                        column: x => x.EntranteId,
                        principalTable: "Entrantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_Postres_PostreId",
                        column: x => x.PostreId,
                        principalTable: "Postres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_Principales_PrincipalId",
                        column: x => x.PrincipalId,
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

            migrationBuilder.CreateIndex(
                name: "IX_Menu_EntranteId",
                table: "Menu",
                column: "EntranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_PostreId",
                table: "Menu",
                column: "PostreId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_PrincipalId",
                table: "Menu",
                column: "PrincipalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Entrantes");

            migrationBuilder.DropTable(
                name: "Postres");

            migrationBuilder.DropTable(
                name: "Principales");
        }
    }
}
