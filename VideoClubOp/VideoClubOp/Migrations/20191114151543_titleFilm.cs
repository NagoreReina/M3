using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoClubOp.Migrations
{
    public partial class titleFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Film",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Film");
        }
    }
}
