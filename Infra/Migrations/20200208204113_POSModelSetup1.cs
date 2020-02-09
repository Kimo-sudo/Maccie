using Microsoft.EntityFrameworkCore.Migrations;


namespace Infra.Migrations
{
    public partial class POSModelSetup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producten_Categories_CategorieId",
                table: "Producten");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Producten",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CategorieNaam",
                table: "Producten",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Producten_Categories_CategorieId",
                table: "Producten",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Producten_Categories_CategorieId",
                table: "Producten",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
