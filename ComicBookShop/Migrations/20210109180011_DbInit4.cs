using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicBookShop.Migrations
{
    public partial class DbInit4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UUID",
                table: "order",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LaunchDate",
                table: "comicbook",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "comicbook",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UUID",
                table: "order");

            migrationBuilder.DropColumn(
                name: "LaunchDate",
                table: "comicbook");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "comicbook");
        }
    }
}
