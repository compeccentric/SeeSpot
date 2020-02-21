using Microsoft.EntityFrameworkCore.Migrations;

namespace SeeSpot.Migrations
{
    public partial class BreedType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedID",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "BreedID",
                table: "Pets",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BreedType",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedID",
                table: "Pets",
                column: "BreedID",
                principalTable: "Breeds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedID",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "BreedType",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "BreedID",
                table: "Pets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedID",
                table: "Pets",
                column: "BreedID",
                principalTable: "Breeds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
