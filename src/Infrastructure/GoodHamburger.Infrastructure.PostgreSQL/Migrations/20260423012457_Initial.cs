using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoodHamburger.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    Subtotal = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("019db7f0-af6a-71b7-b99e-2a92b8540622"), 0, new DateTime(2026, 4, 23, 1, 24, 57, 323, DateTimeKind.Utc).AddTicks(905), "X Egg", 4.50m, null },
                    { new Guid("019db7f0-af6a-721b-b5be-daf2a48398f1"), 2, new DateTime(2026, 4, 23, 1, 24, 57, 323, DateTimeKind.Utc).AddTicks(906), "Soda", 2.50m, null },
                    { new Guid("019db7f0-af6a-7b0f-a0f8-03765816740c"), 0, new DateTime(2026, 4, 23, 1, 24, 57, 323, DateTimeKind.Utc).AddTicks(906), "X Bacon", 7.00m, null },
                    { new Guid("019db7f0-af6a-7c26-9157-84d6db832fc3"), 1, new DateTime(2026, 4, 23, 1, 24, 57, 323, DateTimeKind.Utc).AddTicks(906), "French Fries", 2.00m, null },
                    { new Guid("019db7f0-af6a-7dac-8131-4b732dbf5c48"), 0, new DateTime(2026, 4, 23, 1, 24, 57, 323, DateTimeKind.Utc).AddTicks(576), "X Burger", 5.00m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
