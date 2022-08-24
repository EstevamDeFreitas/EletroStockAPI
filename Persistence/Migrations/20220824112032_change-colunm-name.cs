using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class changecolunmname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_etk_credit_cards_etk_card_flags_CardFlagId",
                table: "etk_credit_cards");

            migrationBuilder.DropForeignKey(
                name: "FK_etk_credit_cards_etk_customers_CustomerId",
                table: "etk_credit_cards");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "etk_credit_cards",
                newName: "customer_id");

            migrationBuilder.RenameColumn(
                name: "CardFlagId",
                table: "etk_credit_cards",
                newName: "card_flag_id");

            migrationBuilder.RenameIndex(
                name: "IX_etk_credit_cards_CustomerId",
                table: "etk_credit_cards",
                newName: "IX_etk_credit_cards_customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_etk_credit_cards_CardFlagId",
                table: "etk_credit_cards",
                newName: "IX_etk_credit_cards_card_flag_id");

            migrationBuilder.AddForeignKey(
                name: "FK_etk_credit_cards_etk_card_flags_card_flag_id",
                table: "etk_credit_cards",
                column: "card_flag_id",
                principalTable: "etk_card_flags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_etk_credit_cards_etk_customers_customer_id",
                table: "etk_credit_cards",
                column: "customer_id",
                principalTable: "etk_customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_etk_credit_cards_etk_card_flags_card_flag_id",
                table: "etk_credit_cards");

            migrationBuilder.DropForeignKey(
                name: "FK_etk_credit_cards_etk_customers_customer_id",
                table: "etk_credit_cards");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "etk_credit_cards",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "card_flag_id",
                table: "etk_credit_cards",
                newName: "CardFlagId");

            migrationBuilder.RenameIndex(
                name: "IX_etk_credit_cards_customer_id",
                table: "etk_credit_cards",
                newName: "IX_etk_credit_cards_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_etk_credit_cards_card_flag_id",
                table: "etk_credit_cards",
                newName: "IX_etk_credit_cards_CardFlagId");

            migrationBuilder.AddForeignKey(
                name: "FK_etk_credit_cards_etk_card_flags_CardFlagId",
                table: "etk_credit_cards",
                column: "CardFlagId",
                principalTable: "etk_card_flags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_etk_credit_cards_etk_customers_CustomerId",
                table: "etk_credit_cards",
                column: "CustomerId",
                principalTable: "etk_customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
