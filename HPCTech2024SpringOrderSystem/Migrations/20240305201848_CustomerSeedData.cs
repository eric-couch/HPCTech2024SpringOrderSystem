using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HPCTech2024SpringOrderSystem.Migrations
{
    /// <inheritdoc />
    public partial class CustomerSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 1, "123 Main St", "eric.couch@cognizant.com", "Eric", "Couch", "123-456-7890" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
