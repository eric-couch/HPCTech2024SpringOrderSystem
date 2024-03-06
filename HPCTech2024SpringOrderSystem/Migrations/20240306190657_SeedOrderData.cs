using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HPCTech2024SpringOrderSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "OrderFullfilled" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 6, 12, 21, 57, 80, DateTimeKind.Local).AddTicks(6333), new DateTime(2024, 3, 6, 12, 41, 57, 80, DateTimeKind.Local).AddTicks(6379) },
                    { 2, 1, new DateTime(2024, 3, 6, 12, 36, 57, 80, DateTimeKind.Local).AddTicks(6404), new DateTime(2024, 3, 6, 12, 51, 57, 80, DateTimeKind.Local).AddTicks(6406) }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
