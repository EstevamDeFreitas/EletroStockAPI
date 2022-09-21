using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class shoppingcart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "etk_shopping_carts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dt_cart_validity = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_shopping_carts", x => x.id);
                    table.ForeignKey(
                        name: "FK_etk_shopping_carts_etk_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "etk_customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "etk_shopping_cart_items",
                columns: table => new
                {
                    shopping_cart_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<long>(type: "bigint", nullable: false),
                    ShoppingCartId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_shopping_cart_items", x => x.shopping_cart_id);
                    table.ForeignKey(
                        name: "FK_etk_shopping_cart_items_etk_products_product_id",
                        column: x => x.product_id,
                        principalTable: "etk_products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_etk_shopping_cart_items_etk_shopping_carts_ShoppingCartId1",
                        column: x => x.ShoppingCartId1,
                        principalTable: "etk_shopping_carts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_etk_shopping_cart_items_product_id",
                table: "etk_shopping_cart_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_shopping_cart_items_ShoppingCartId1",
                table: "etk_shopping_cart_items",
                column: "ShoppingCartId1");

            migrationBuilder.CreateIndex(
                name: "IX_etk_shopping_carts_customer_id",
                table: "etk_shopping_carts",
                column: "customer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "etk_shopping_cart_items");

            migrationBuilder.DropTable(
                name: "etk_shopping_carts");
        }
    }
}
