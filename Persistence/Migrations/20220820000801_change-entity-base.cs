using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class changeentitybase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "etk_dt_modified",
                table: "etk_customers",
                newName: "dt_modified");

            migrationBuilder.RenameColumn(
                name: "etk_dt_creation",
                table: "etk_customers",
                newName: "dt_creation");

            migrationBuilder.RenameColumn(
                name: "etk_id",
                table: "etk_customers",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dt_modified",
                table: "etk_customers",
                newName: "etk_dt_modified");

            migrationBuilder.RenameColumn(
                name: "dt_creation",
                table: "etk_customers",
                newName: "etk_dt_creation");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "etk_customers",
                newName: "etk_id");
        }
    }
}
