using Microsoft.EntityFrameworkCore.Migrations;

namespace SeeSpot.Migrations
{
    public partial class Breeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BreedID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Breeds_Breeds_BreedID",
                        column: x => x.BreedID,
                        principalTable: "Breeds",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_BreedID",
                table: "Breeds",
                column: "BreedID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breeds");
        }
    }
}
