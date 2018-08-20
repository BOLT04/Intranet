using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class ChangedtoMACaddressforScreens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Screens",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "TerminalId",
                table: "Screens");

            migrationBuilder.RenameColumn(
                name: "SiteId",
                table: "Sites",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Screens",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "MACAddress",
                table: "Screens",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Screens",
                table: "Screens",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Screens",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "MACAddress",
                table: "Screens");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sites",
                newName: "SiteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.AddColumn<string>(
                name: "TerminalId",
                table: "Screens",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Screens",
                table: "Screens",
                column: "TerminalId");
        }
    }
}
