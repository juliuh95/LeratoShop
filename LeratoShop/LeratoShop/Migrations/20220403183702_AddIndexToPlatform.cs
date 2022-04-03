using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeratoShop.Migrations
{
    public partial class AddIndexToPlatform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Platforms_Name",
                table: "Platforms",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Platforms_Name",
                table: "Platforms");
        }
    }
}
