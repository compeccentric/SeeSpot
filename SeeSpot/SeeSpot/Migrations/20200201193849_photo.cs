using Microsoft.EntityFrameworkCore.Migrations;

namespace SeeSpot.Migrations
{
    public partial class photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Pets");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Pets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Pets");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
