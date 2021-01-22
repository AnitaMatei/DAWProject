using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicBookShop.Migrations
{
    public partial class DbDAW3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "comicbook",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "comicbook",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
