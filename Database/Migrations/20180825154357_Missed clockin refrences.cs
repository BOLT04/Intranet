using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class Missedclockinrefrences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clockins_Employees_EmployeeId",
                table: "Clockins");

            migrationBuilder.DropForeignKey(
                name: "FK_Clockins_Sites_SiteId",
                table: "Clockins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clockins",
                table: "Clockins");

            migrationBuilder.RenameTable(
                name: "Clockins",
                newName: "Signins");

            migrationBuilder.RenameIndex(
                name: "IX_Clockins_SiteId",
                table: "Signins",
                newName: "IX_Signins_SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Clockins_EmployeeId",
                table: "Signins",
                newName: "IX_Signins_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Signins",
                table: "Signins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Signins_Employees_EmployeeId",
                table: "Signins",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Signins_Sites_SiteId",
                table: "Signins",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signins_Employees_EmployeeId",
                table: "Signins");

            migrationBuilder.DropForeignKey(
                name: "FK_Signins_Sites_SiteId",
                table: "Signins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Signins",
                table: "Signins");

            migrationBuilder.RenameTable(
                name: "Signins",
                newName: "Clockins");

            migrationBuilder.RenameIndex(
                name: "IX_Signins_SiteId",
                table: "Clockins",
                newName: "IX_Clockins_SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Signins_EmployeeId",
                table: "Clockins",
                newName: "IX_Clockins_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clockins",
                table: "Clockins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clockins_Employees_EmployeeId",
                table: "Clockins",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clockins_Sites_SiteId",
                table: "Clockins",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
