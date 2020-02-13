using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Back : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FrietAfgerond",
                table: "Bestellingen",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BesteldeProducten",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BesteldeProducten",
                table: "BesteldeProducten",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BesteldeProducten_OrderId",
                table: "BesteldeProducten",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BesteldeProducten_Bestellingen_OrderId",
                table: "BesteldeProducten",
                column: "OrderId",
                principalTable: "Bestellingen",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BesteldeProducten_Bestellingen_OrderId",
                table: "BesteldeProducten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BesteldeProducten",
                table: "BesteldeProducten");

            migrationBuilder.DropIndex(
                name: "IX_BesteldeProducten_OrderId",
                table: "BesteldeProducten");

            migrationBuilder.DropColumn(
                name: "FrietAfgerond",
                table: "Bestellingen");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BesteldeProducten");
        }
    }
}
