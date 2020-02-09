using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class POSModelSetup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producten_Categories_CategorieId",
                table: "Producten");

            migrationBuilder.DropColumn(
                name: "CategorieNaam",
                table: "Producten");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Producten",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Actief",
                table: "Producten",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Producten_Categories_CategorieId",
                table: "Producten",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producten_Categories_CategorieId",
                table: "Producten");

            migrationBuilder.DropColumn(
                name: "Actief",
                table: "Producten");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Producten",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "CategorieNaam",
                table: "Producten",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Producten_Categories_CategorieId",
                table: "Producten",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
