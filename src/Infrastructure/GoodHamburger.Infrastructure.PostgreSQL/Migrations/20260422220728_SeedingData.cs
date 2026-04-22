using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoodHamburger.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Name", "Price", "ProductCategory", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("019db73b-e14a-7053-a8b8-6394480ff877"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "X Egg", 4.50m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("019db73b-e14a-7432-b478-daa0c61217a2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Fries", 2.00m, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("019db73b-e14a-745d-b80c-b5dffb27fdcf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Soda", 2.50m, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("019db73b-e14a-7687-9105-811b1c33fa05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "X Bacon", 7.00m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("019db73b-e14a-7eb1-90f6-d52203ba3416"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "X Burger", 5.00m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("019db73b-e14a-7053-a8b8-6394480ff877"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("019db73b-e14a-7432-b478-daa0c61217a2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("019db73b-e14a-745d-b80c-b5dffb27fdcf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("019db73b-e14a-7687-9105-811b1c33fa05"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("019db73b-e14a-7eb1-90f6-d52203ba3416"));
        }
    }
}
