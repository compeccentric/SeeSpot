using Microsoft.EntityFrameworkCore.Migrations;

namespace SeeSpot.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Pets_PetID",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetID",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetID",
                table: "Pets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetID",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetID",
                table: "Pets",
                column: "PetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Pets_PetID",
                table: "Pets",
                column: "PetID",
                principalTable: "Pets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
