using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Afgerond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Afgerond",
                table: "Bestellingen",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DrankjesAfgerond",
                table: "Bestellingen",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FrietAfgerond",
                table: "Bestellingen",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "KeukenAfgerond",
                table: "Bestellingen",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Afgerond",
                table: "Bestellingen");

            migrationBuilder.DropColumn(
                name: "DrankjesAfgerond",
                table: "Bestellingen");

            migrationBuilder.DropColumn(
                name: "FrietAfgerond",
                table: "Bestellingen");

            migrationBuilder.DropColumn(
                name: "KeukenAfgerond",
                table: "Bestellingen");
        }
    }
}
