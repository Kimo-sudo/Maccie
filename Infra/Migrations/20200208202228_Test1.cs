using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BesteldeProducten_Employees_EmployeeId",
                table: "BesteldeProducten");

            migrationBuilder.DropIndex(
                name: "IX_BesteldeProducten_EmployeeId",
                table: "BesteldeProducten");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "BesteldeProducten");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BesteldeProducten");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "BesteldeProducten");

            migrationBuilder.AddColumn<int>(
                name: "Hoeveelheid",
                table: "BesteldeProducten",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hoeveelheid",
                table: "BesteldeProducten");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "BesteldeProducten",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "BesteldeProducten",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "BesteldeProducten",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BesteldeProducten_EmployeeId",
                table: "BesteldeProducten",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BesteldeProducten_Employees_EmployeeId",
                table: "BesteldeProducten",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
