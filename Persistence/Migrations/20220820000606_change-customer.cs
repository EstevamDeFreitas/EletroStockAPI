using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class changecustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "etk_ranking",
                table: "etk_customers",
                newName: "ranking");

            migrationBuilder.RenameColumn(
                name: "etk_phone_type",
                table: "etk_customers",
                newName: "phone_type");

            migrationBuilder.RenameColumn(
                name: "etk_phone_number",
                table: "etk_customers",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "etk_phone_code",
                table: "etk_customers",
                newName: "phone_code");

            migrationBuilder.RenameColumn(
                name: "etk_password",
                table: "etk_customers",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "etk_name",
                table: "etk_customers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "etk_gender",
                table: "etk_customers",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "etk_email",
                table: "etk_customers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "etk_cpf",
                table: "etk_customers",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "etk_birth_date",
                table: "etk_customers",
                newName: "birth_date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ranking",
                table: "etk_customers",
                newName: "etk_ranking");

            migrationBuilder.RenameColumn(
                name: "phone_type",
                table: "etk_customers",
                newName: "etk_phone_type");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "etk_customers",
                newName: "etk_phone_number");

            migrationBuilder.RenameColumn(
                name: "phone_code",
                table: "etk_customers",
                newName: "etk_phone_code");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "etk_customers",
                newName: "etk_password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "etk_customers",
                newName: "etk_name");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "etk_customers",
                newName: "etk_gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "etk_customers",
                newName: "etk_email");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "etk_customers",
                newName: "etk_cpf");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "etk_customers",
                newName: "etk_birth_date");
        }
    }
}
