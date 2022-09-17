using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class productrelationchangeinactivereason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_etk_products_etk_inactive_reasons_inactive_reason_id",
                table: "etk_products");

            migrationBuilder.AlterColumn<Guid>(
                name: "inactive_reason_id",
                table: "etk_products",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_etk_products_etk_inactive_reasons_inactive_reason_id",
                table: "etk_products",
                column: "inactive_reason_id",
                principalTable: "etk_inactive_reasons",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_etk_products_etk_inactive_reasons_inactive_reason_id",
                table: "etk_products");

            migrationBuilder.AlterColumn<Guid>(
                name: "inactive_reason_id",
                table: "etk_products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_etk_products_etk_inactive_reasons_inactive_reason_id",
                table: "etk_products",
                column: "inactive_reason_id",
                principalTable: "etk_inactive_reasons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
