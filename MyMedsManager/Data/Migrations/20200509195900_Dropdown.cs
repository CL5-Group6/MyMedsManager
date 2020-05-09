using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMedsManager.Data.Migrations
{
    public partial class Dropdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "Medication");

            migrationBuilder.AlterColumn<string>(
                name: "Medicine",
                table: "Medication",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<int>(
                name: "DosageValue",
                table: "Medication",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FrequencyValue",
                table: "Medication",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Medication",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DosageValue",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "FrequencyValue",
                table: "Medication");

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

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "Medication",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
