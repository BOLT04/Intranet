using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class ChangedtoAuthcodeforScreens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MACAddress",
                table: "Screens",
                newName: "AuthCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthCode",
                table: "Screens",
                newName: "MACAddress");
        }
    }
}
