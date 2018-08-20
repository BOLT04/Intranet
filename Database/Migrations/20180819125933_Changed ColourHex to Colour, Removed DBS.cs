using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class ChangedColourHextoColourRemovedDBS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColourHex",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "DBS",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Sites",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Sites");

            migrationBuilder.AddColumn<string>(
                name: "ColourHex",
                table: "Sites",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DBS",
                table: "Employees",
                nullable: false,
                defaultValue: "");
        }
    }
}
