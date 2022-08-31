using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class optional_account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_etk_customer_accounts_etk_credit_cards_default_credit_card_~",
                table: "etk_customer_accounts");

            migrationBuilder.DropIndex(
                name: "IX_etk_customer_accounts_default_charge_address_id",
                table: "etk_customer_accounts");

            migrationBuilder.DropIndex(
                name: "IX_etk_customer_accounts_default_delivery_address_id",
                table: "etk_customer_accounts");

            migrationBuilder.AlterColumn<Guid>(
                name: "default_delivery_address_id",
                table: "etk_customer_accounts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "default_credit_card_id",
                table: "etk_customer_accounts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "default_charge_address_id",
                table: "etk_customer_accounts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_etk_customer_accounts_default_charge_address_id",
                table: "etk_customer_accounts",
                column: "default_charge_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_etk_customer_accounts_default_delivery_address_id",
                table: "etk_customer_accounts",
                column: "default_delivery_address_id");

            migrationBuilder.AddForeignKey(
                name: "FK_etk_customer_accounts_etk_credit_cards_default_credit_card_~",
                table: "etk_customer_accounts",
                column: "default_credit_card_id",
                principalTable: "etk_credit_cards",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_etk_customer_accounts_etk_credit_cards_default_credit_card_~",
                table: "etk_customer_accounts");

            migrationBuilder.DropIndex(
                name: "IX_etk_customer_accounts_default_charge_address_id",
                table: "etk_customer_accounts");

            migrationBuilder.DropIndex(
                name: "IX_etk_customer_accounts_default_delivery_address_id",
                table: "etk_customer_accounts");

            migrationBuilder.AlterColumn<Guid>(
                name: "default_delivery_address_id",
                table: "etk_customer_accounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "default_credit_card_id",
                table: "etk_customer_accounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "default_charge_address_id",
                table: "etk_customer_accounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_etk_customer_accounts_default_charge_address_id",
                table: "etk_customer_accounts",
                column: "default_charge_address_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_etk_customer_accounts_default_delivery_address_id",
                table: "etk_customer_accounts",
                column: "default_delivery_address_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_etk_customer_accounts_etk_credit_cards_default_credit_card_~",
                table: "etk_customer_accounts",
                column: "default_credit_card_id",
                principalTable: "etk_credit_cards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
