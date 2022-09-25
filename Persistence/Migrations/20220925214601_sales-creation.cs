using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class salescreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "etk_coupons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    coupon_type = table.Column<int>(type: "integer", nullable: false),
                    dt_validity = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    has_validity = table.Column<bool>(type: "boolean", nullable: false),
                    value = table.Column<decimal>(type: "numeric", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_coupons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "etk_customer_coupons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    coupon_id = table.Column<Guid>(type: "uuid", nullable: false),
                    value_remaining = table.Column<decimal>(type: "numeric", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_customer_coupons", x => x.id);
                    table.ForeignKey(
                        name: "FK_etk_customer_coupons_etk_coupons_coupon_id",
                        column: x => x.coupon_id,
                        principalTable: "etk_coupons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_etk_customer_coupons_etk_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "etk_customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "etk_sales",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    address_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sale_status = table.Column<int>(type: "integer", nullable: false),
                    dt_sale = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vl_shipping = table.Column<decimal>(type: "numeric", nullable: false),
                    CouponCustomerId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreditCardId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_sales", x => x.id);
                    table.ForeignKey(
                        name: "FK_etk_sales_etk_addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "etk_addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_etk_sales_etk_credit_cards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "etk_credit_cards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_etk_sales_etk_customer_coupons_CouponCustomerId",
                        column: x => x.CouponCustomerId,
                        principalTable: "etk_customer_coupons",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_etk_sales_etk_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "etk_customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_etk_sales_etk_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "etk_products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "etk_sale_coupons",
                columns: table => new
                {
                    customer_coupon_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sale_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vl_discount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_sale_coupons", x => new { x.sale_id, x.customer_coupon_id });
                    table.ForeignKey(
                        name: "FK_etk_sale_coupons_etk_customer_coupons_customer_coupon_id",
                        column: x => x.customer_coupon_id,
                        principalTable: "etk_customer_coupons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_etk_sale_coupons_etk_sales_sale_id",
                        column: x => x.sale_id,
                        principalTable: "etk_sales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "etk_sale_items",
                columns: table => new
                {
                    sale_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    refund_status = table.Column<int>(type: "integer", nullable: false),
                    vl_unit = table.Column<decimal>(type: "numeric", nullable: false),
                    quantity = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_sale_items", x => new { x.product_id, x.sale_id });
                    table.ForeignKey(
                        name: "FK_etk_sale_items_etk_products_product_id",
                        column: x => x.product_id,
                        principalTable: "etk_products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_etk_sale_items_etk_sales_sale_id",
                        column: x => x.sale_id,
                        principalTable: "etk_sales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "etk_sale_payments",
                columns: table => new
                {
                    credit_card_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sale_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vl_paid = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_sale_payments", x => new { x.sale_id, x.credit_card_id });
                    table.ForeignKey(
                        name: "FK_etk_sale_payments_etk_credit_cards_credit_card_id",
                        column: x => x.credit_card_id,
                        principalTable: "etk_credit_cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_etk_sale_payments_etk_sales_sale_id",
                        column: x => x.sale_id,
                        principalTable: "etk_sales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_etk_customer_coupons_coupon_id",
                table: "etk_customer_coupons",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_customer_coupons_customer_id",
                table: "etk_customer_coupons",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_sale_coupons_customer_coupon_id",
                table: "etk_sale_coupons",
                column: "customer_coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_sale_items_sale_id",
                table: "etk_sale_items",
                column: "sale_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_sale_payments_credit_card_id",
                table: "etk_sale_payments",
                column: "credit_card_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_sales_address_id",
                table: "etk_sales",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_sales_CouponCustomerId",
                table: "etk_sales",
                column: "CouponCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_etk_sales_CreditCardId",
                table: "etk_sales",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_etk_sales_customer_id",
                table: "etk_sales",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_sales_ProductId",
                table: "etk_sales",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "etk_sale_coupons");

            migrationBuilder.DropTable(
                name: "etk_sale_items");

            migrationBuilder.DropTable(
                name: "etk_sale_payments");

            migrationBuilder.DropTable(
                name: "etk_sales");

            migrationBuilder.DropTable(
                name: "etk_customer_coupons");

            migrationBuilder.DropTable(
                name: "etk_coupons");
        }
    }
}
