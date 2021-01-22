using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicBookShop.Migrations
{
    public partial class DBInit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Street = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "comicbook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ComicType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comicbook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DeliveryAddressID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_address_DeliveryAddressID",
                        column: x => x.DeliveryAddressID,
                        principalTable: "address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cartitem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CorrespondingComicBookId = table.Column<int>(nullable: false),
                    InUsersCartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartitem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartitem_comicbook_CorrespondingComicBookId",
                        column: x => x.CorrespondingComicBookId,
                        principalTable: "comicbook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cartitem_user_InUsersCartId",
                        column: x => x.InUsersCartId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Details = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DeliveryAddressId = table.Column<int>(nullable: false),
                    OrderedByUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_address_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_user_OrderedByUserId",
                        column: x => x.OrderedByUserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ordercomicbook",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    ComicBookId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdatedTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordercomicbook", x => new { x.OrderId, x.ComicBookId });
                    table.ForeignKey(
                        name: "FK_ordercomicbook_comicbook_ComicBookId",
                        column: x => x.ComicBookId,
                        principalTable: "comicbook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordercomicbook_order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartitem_CorrespondingComicBookId",
                table: "cartitem",
                column: "CorrespondingComicBookId");

            migrationBuilder.CreateIndex(
                name: "IX_cartitem_InUsersCartId",
                table: "cartitem",
                column: "InUsersCartId");

            migrationBuilder.CreateIndex(
                name: "IX_order_DeliveryAddressId",
                table: "order",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_order_OrderedByUserId",
                table: "order",
                column: "OrderedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ordercomicbook_ComicBookId",
                table: "ordercomicbook",
                column: "ComicBookId");

            migrationBuilder.CreateIndex(
                name: "IX_user_DeliveryAddressID",
                table: "user",
                column: "DeliveryAddressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartitem");

            migrationBuilder.DropTable(
                name: "ordercomicbook");

            migrationBuilder.DropTable(
                name: "comicbook");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "address");
        }
    }
}
