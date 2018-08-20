using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class SiteColourHex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColourHex",
                table: "Sites",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColourHex",
                table: "Sites");
        }
    }
}
