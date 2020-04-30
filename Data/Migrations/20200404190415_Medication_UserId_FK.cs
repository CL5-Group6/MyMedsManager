using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMedsManager.Data.Migrations
{
    public partial class Medication_UserId_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Medicine",
                table: "Medication",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Medication",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Medication");

            migrationBuilder.AlterColumn<string>(
                name: "Medicine",
                table: "Medication",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
