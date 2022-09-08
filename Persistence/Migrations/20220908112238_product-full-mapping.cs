using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class productfullmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "etk_categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "etk_inactive_categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_inactive_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "etk_price_groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    profit_margin = table.Column<decimal>(type: "numeric", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_price_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "etk_inactive_reasons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    inactive_category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_inactive_reasons", x => x.id);
                    table.ForeignKey(
                        name: "FK_etk_inactive_reasons_etk_inactive_categories_inactive_categ~",
                        column: x => x.inactive_category_id,
                        principalTable: "etk_inactive_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "etk_products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    price_group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    inactive_reason_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_etk_products_etk_inactive_reasons_inactive_reason_id",
                        column: x => x.inactive_reason_id,
                        principalTable: "etk_inactive_reasons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_etk_products_etk_price_groups_price_group_id",
                        column: x => x.price_group_id,
                        principalTable: "etk_price_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "etk_product_categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_product_categories", x => x.id);
                    table.ForeignKey(
                        name: "FK_etk_product_categories_etk_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "etk_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_etk_product_categories_etk_products_product_id",
                        column: x => x.product_id,
                        principalTable: "etk_products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "etk_product_images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_product_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_etk_product_images_etk_products_product_id",
                        column: x => x.product_id,
                        principalTable: "etk_products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_etk_inactive_reasons_inactive_category_id",
                table: "etk_inactive_reasons",
                column: "inactive_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_product_categories_category_id",
                table: "etk_product_categories",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_product_categories_product_id",
                table: "etk_product_categories",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_product_images_product_id",
                table: "etk_product_images",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_products_inactive_reason_id",
                table: "etk_products",
                column: "inactive_reason_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_products_price_group_id",
                table: "etk_products",
                column: "price_group_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "etk_product_categories");

            migrationBuilder.DropTable(
                name: "etk_product_images");

            migrationBuilder.DropTable(
                name: "etk_categories");

            migrationBuilder.DropTable(
                name: "etk_products");

            migrationBuilder.DropTable(
                name: "etk_inactive_reasons");

            migrationBuilder.DropTable(
                name: "etk_price_groups");

            migrationBuilder.DropTable(
                name: "etk_inactive_categories");
        }
    }
}
