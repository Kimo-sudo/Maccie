using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class OrderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BesteldeProducten_Bestellingen_OrderId",
                table: "BesteldeProducten");

            migrationBuilder.DropForeignKey(
                name: "FK_BesteldeProducten_Producten_ProductId",
                table: "BesteldeProducten");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "BesteldeProducten",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "BesteldeProducten",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BesteldeProducten_Bestellingen_OrderId",
                table: "BesteldeProducten",
                column: "OrderId",
                principalTable: "Bestellingen",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BesteldeProducten_Producten_ProductId",
                table: "BesteldeProducten",
                column: "ProductId",
                principalTable: "Producten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BesteldeProducten_Bestellingen_OrderId",
                table: "BesteldeProducten");

            migrationBuilder.DropForeignKey(
                name: "FK_BesteldeProducten_Producten_ProductId",
                table: "BesteldeProducten");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "BesteldeProducten",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "BesteldeProducten",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BesteldeProducten_Bestellingen_OrderId",
                table: "BesteldeProducten",
                column: "OrderId",
                principalTable: "Bestellingen",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BesteldeProducten_Producten_ProductId",
                table: "BesteldeProducten",
                column: "ProductId",
                principalTable: "Producten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
