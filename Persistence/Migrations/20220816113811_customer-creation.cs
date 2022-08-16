using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class customercreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "etk_customers",
                columns: table => new
                {
                    etk_id = table.Column<Guid>(type: "uuid", nullable: false),
                    etk_email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    etk_password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    etk_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    etk_gender = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false),
                    etk_birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    etk_cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    etk_phone_type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    etk_phone_code = table.Column<decimal>(type: "numeric", maxLength: 3, nullable: false),
                    etk_phone_number = table.Column<decimal>(type: "numeric", maxLength: 9, nullable: false),
                    etk_ranking = table.Column<int>(type: "integer", nullable: false),
                    etk_dt_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    etk_dt_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etk_customers", x => x.etk_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "etk_customers");
        }
    }
}
