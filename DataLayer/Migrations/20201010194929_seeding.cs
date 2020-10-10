using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(19,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandID", "Name" },
                values: new object[] { 1, "90° Company" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "BrandID", "Name", "Price" },
                values: new object[] { 3, null, "None", -1m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "BrandID", "Name", "Price" },
                values: new object[] { 1, 1, "SomeSquare", 8m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "BrandID", "Name", "Price" },
                values: new object[] { 2, 1, "Non Euclidean Pentagon", 5m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");
        }
    }
}
