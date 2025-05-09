using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialProductionSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "production");

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "production",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    category_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_id", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                schema: "production",
                columns: table => new
                {
                    store_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    store_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    store_contact_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    store_phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_store_id", x => x.store_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "production",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_sku = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    product_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    product_stock_quantity = table.Column<int>(type: "int", nullable: false),
                    product_is_active = table.Column<bool>(type: "bit", nullable: false),
                    product_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    store_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_id", x => x.product_id);
                    table.ForeignKey(
                        name: "fk_product_category_id",
                        column: x => x.category_id,
                        principalSchema: "production",
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_store_id",
                        column: x => x.store_id,
                        principalSchema: "production",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_category_name",
                schema: "production",
                table: "categories",
                column: "category_name");

            migrationBuilder.CreateIndex(
                name: "idx_product_category_id",
                schema: "production",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "idx_product_sku",
                schema: "production",
                table: "products",
                column: "product_sku");

            migrationBuilder.CreateIndex(
                name: "idx_product_store_id",
                schema: "production",
                table: "products",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "idx_store_name",
                schema: "production",
                table: "stores",
                column: "store_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products",
                schema: "production");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "production");

            migrationBuilder.DropTable(
                name: "stores",
                schema: "production");
        }
    }
}
