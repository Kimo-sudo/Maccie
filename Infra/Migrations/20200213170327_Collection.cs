using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Collection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "BesteldeProducten");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "BesteldeProducten",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
