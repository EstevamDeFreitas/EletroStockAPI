using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class creditcardcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "etk_card_flags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_card_flags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "etk_credit_cards",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    card_number = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    owner_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CardFlagId = table.Column<Guid>(type: "uuid", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_credit_cards", x => x.id);
                    table.ForeignKey(
                        name: "FK_etk_credit_cards_etk_card_flags_CardFlagId",
                        column: x => x.CardFlagId,
                        principalTable: "etk_card_flags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_etk_credit_cards_etk_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "etk_customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "etk_customer_accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    default_charge_address_id = table.Column<Guid>(type: "uuid", nullable: false),
                    default_delivery_address_id = table.Column<Guid>(type: "uuid", nullable: false),
                    default_credit_card_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_customer_accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_etk_customer_accounts_etk_addresses_default_charge_address_~",
                        column: x => x.default_charge_address_id,
                        principalTable: "etk_addresses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_etk_customer_accounts_etk_addresses_default_delivery_addres~",
                        column: x => x.default_delivery_address_id,
                        principalTable: "etk_addresses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_etk_customer_accounts_etk_credit_cards_default_credit_card_~",
                        column: x => x.default_credit_card_id,
                        principalTable: "etk_credit_cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_etk_customer_accounts_etk_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "etk_customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_etk_credit_cards_CardFlagId",
                table: "etk_credit_cards",
                column: "CardFlagId");

            migrationBuilder.CreateIndex(
                name: "IX_etk_credit_cards_CustomerId",
                table: "etk_credit_cards",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_etk_customer_accounts_customer_id",
                table: "etk_customer_accounts",
                column: "customer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_etk_customer_accounts_default_charge_address_id",
                table: "etk_customer_accounts",
                column: "default_charge_address_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_etk_customer_accounts_default_credit_card_id",
                table: "etk_customer_accounts",
                column: "default_credit_card_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_etk_customer_accounts_default_delivery_address_id",
                table: "etk_customer_accounts",
                column: "default_delivery_address_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "etk_customer_accounts");

            migrationBuilder.DropTable(
                name: "etk_credit_cards");

            migrationBuilder.DropTable(
                name: "etk_card_flags");
        }
    }
}
