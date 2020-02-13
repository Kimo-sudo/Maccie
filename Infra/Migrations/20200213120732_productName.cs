using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class productName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "BesteldeProducten",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "BesteldeProducten");
        }
    }
}
