using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class SiteNameIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sites",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Sites_Name",
                table: "Sites",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sites_Name",
                table: "Sites");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sites",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
