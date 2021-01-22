using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicBookShop.Migrations
{
    public partial class DbDAW2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverUrl",
                table: "comicbook",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverUrl",
                table: "comicbook");
        }
    }
}
