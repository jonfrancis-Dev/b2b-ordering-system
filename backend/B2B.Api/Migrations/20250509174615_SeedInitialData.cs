using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "production",
                table: "categories",
                columns: new[] { "category_id", "category_description", "category_name" },
                values: new object[] { 1, "Electronic gadgets and devices", "Electronics" });

            migrationBuilder.InsertData(
                schema: "production",
                table: "stores",
                columns: new[] { "store_id", "store_address", "store_contact_email", "store_name", "store_phone_number" },
                values: new object[] { 1, "123 Commerce Rd", "info@wholesalecentral.com", "Wholesale Central", "555-1234" });

            migrationBuilder.InsertData(
                schema: "production",
                table: "products",
                columns: new[] { "product_id", "product_brand", "category_id", "product_description", "product_image_url", "product_is_active", "product_name", "product_price", "product_sku", "product_stock_quantity", "store_id" },
                values: new object[] { 1, "LogiTech", 1, "Ergonomic wireless mouse", "https://example.com/mouse.jpg", true, "Wireless Mouse", 24.99m, "LOG-MSE-001", 100, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "production",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "production",
                table: "stores",
                keyColumn: "store_id",
                keyValue: 1);
        }
    }
}
