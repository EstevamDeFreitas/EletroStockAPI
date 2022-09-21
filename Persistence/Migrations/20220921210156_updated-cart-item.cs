using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class updatedcartitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_etk_shopping_cart_items_etk_shopping_carts_ShoppingCartId1",
                table: "etk_shopping_cart_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_etk_shopping_cart_items",
                table: "etk_shopping_cart_items");

            migrationBuilder.DropIndex(
                name: "IX_etk_shopping_cart_items_product_id",
                table: "etk_shopping_cart_items");

            migrationBuilder.DropIndex(
                name: "IX_etk_shopping_cart_items_ShoppingCartId1",
                table: "etk_shopping_cart_items");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId1",
                table: "etk_shopping_cart_items");

            migrationBuilder.AddPrimaryKey(
                name: "PK_etk_shopping_cart_items",
                table: "etk_shopping_cart_items",
                columns: new[] { "product_id", "shopping_cart_id" });

            migrationBuilder.CreateIndex(
                name: "IX_etk_shopping_cart_items_shopping_cart_id",
                table: "etk_shopping_cart_items",
                column: "shopping_cart_id");

            migrationBuilder.AddForeignKey(
                name: "FK_etk_shopping_cart_items_etk_shopping_carts_shopping_cart_id",
                table: "etk_shopping_cart_items",
                column: "shopping_cart_id",
                principalTable: "etk_shopping_carts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_etk_shopping_cart_items_etk_shopping_carts_shopping_cart_id",
                table: "etk_shopping_cart_items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_etk_shopping_cart_items",
                table: "etk_shopping_cart_items");

            migrationBuilder.DropIndex(
                name: "IX_etk_shopping_cart_items_shopping_cart_id",
                table: "etk_shopping_cart_items");

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingCartId1",
                table: "etk_shopping_cart_items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_etk_shopping_cart_items",
                table: "etk_shopping_cart_items",
                column: "shopping_cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_shopping_cart_items_product_id",
                table: "etk_shopping_cart_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_shopping_cart_items_ShoppingCartId1",
                table: "etk_shopping_cart_items",
                column: "ShoppingCartId1");

            migrationBuilder.AddForeignKey(
                name: "FK_etk_shopping_cart_items_etk_shopping_carts_ShoppingCartId1",
                table: "etk_shopping_cart_items",
                column: "ShoppingCartId1",
                principalTable: "etk_shopping_carts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
