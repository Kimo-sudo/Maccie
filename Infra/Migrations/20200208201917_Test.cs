using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producten_Bestellingen_OrderId",
                table: "Producten");

            migrationBuilder.DropIndex(
                name: "IX_Producten_OrderId",
                table: "Producten");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Producten");

            migrationBuilder.DropColumn(
                name: "DatumVerstuurd",
                table: "Bestellingen");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDateTime",
                table: "Bestellingen",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BesteldeProducten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BesteldeProducten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BesteldeProducten_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BesteldeProducten_Bestellingen_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Bestellingen",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BesteldeProducten_Producten_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Producten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BesteldeProducten_EmployeeId",
                table: "BesteldeProducten",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BesteldeProducten_OrderId",
                table: "BesteldeProducten",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BesteldeProducten_ProductId",
                table: "BesteldeProducten",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BesteldeProducten");

            migrationBuilder.DropColumn(
                name: "OrderDateTime",
                table: "Bestellingen");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Producten",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumVerstuurd",
                table: "Bestellingen",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Producten_OrderId",
                table: "Producten",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producten_Bestellingen_OrderId",
                table: "Producten",
                column: "OrderId",
                principalTable: "Bestellingen",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
