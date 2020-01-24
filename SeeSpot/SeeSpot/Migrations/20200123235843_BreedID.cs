using Microsoft.EntityFrameworkCore.Migrations;

namespace SeeSpot.Migrations
{
    public partial class BreedID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Breeds_BreedID",
                table: "Breeds");

            migrationBuilder.DropIndex(
                name: "IX_Breeds_BreedID",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "BreedID",
                table: "Breeds");

            migrationBuilder.AddColumn<int>(
                name: "BreedID",
                table: "Pets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_BreedID",
                table: "Pets",
                column: "BreedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Breeds_BreedID",
                table: "Pets",
                column: "BreedID",
                principalTable: "Breeds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Breeds_BreedID",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_BreedID",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "BreedID",
                table: "Pets");

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BreedID",
                table: "Breeds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_BreedID",
                table: "Breeds",
                column: "BreedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Breeds_BreedID",
                table: "Breeds",
                column: "BreedID",
                principalTable: "Breeds",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
