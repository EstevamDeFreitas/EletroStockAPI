using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class entitiesrelationchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_etk_product_categories",
                table: "etk_product_categories");

            migrationBuilder.DropIndex(
                name: "IX_etk_product_categories_product_id",
                table: "etk_product_categories");

            migrationBuilder.DropColumn(
                name: "id",
                table: "etk_product_categories");

            migrationBuilder.DropColumn(
                name: "dt_creation",
                table: "etk_product_categories");

            migrationBuilder.DropColumn(
                name: "dt_modified",
                table: "etk_product_categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_etk_product_categories",
                table: "etk_product_categories",
                columns: new[] { "product_id", "category_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_etk_product_categories",
                table: "etk_product_categories");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "etk_product_categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_creation",
                table: "etk_product_categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_modified",
                table: "etk_product_categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_etk_product_categories",
                table: "etk_product_categories",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_product_categories_product_id",
                table: "etk_product_categories",
                column: "product_id");
        }
    }
}
