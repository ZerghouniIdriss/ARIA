using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPA.Data.Migrations
{
    /// <inheritdoc />
    public partial class extendtimesheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "D6",
                table: "TimeSheets",
                newName: "D6Vacation");

            migrationBuilder.RenameColumn(
                name: "D5",
                table: "TimeSheets",
                newName: "D6Regular");

            migrationBuilder.RenameColumn(
                name: "D4",
                table: "TimeSheets",
                newName: "D6Overtime");

            migrationBuilder.RenameColumn(
                name: "D3",
                table: "TimeSheets",
                newName: "D6Holiday");

            migrationBuilder.RenameColumn(
                name: "D2",
                table: "TimeSheets",
                newName: "D5Vacation");

            migrationBuilder.RenameColumn(
                name: "D1",
                table: "TimeSheets",
                newName: "D5Regular");

            migrationBuilder.RenameColumn(
                name: "D0",
                table: "TimeSheets",
                newName: "D5Overtime");

            migrationBuilder.AddColumn<double>(
                name: "D0Holiday",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D0Overtime",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D0Regular",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D0Vacation",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D1Holiday",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D1Overtime",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D1Regular",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D1Vacation",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D2Holiday",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D2Overtime",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D2Regular",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D2Vacation",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D3Holiday",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D3Overtime",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D3Regular",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D3Vacation",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D4Holiday",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D4Overtime",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D4Regular",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D4Vacation",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D5Holiday",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "D0Holiday",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D0Overtime",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D0Regular",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D0Vacation",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D1Holiday",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D1Overtime",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D1Regular",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D1Vacation",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D2Holiday",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D2Overtime",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D2Regular",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D2Vacation",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D3Holiday",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D3Overtime",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D3Regular",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D3Vacation",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D4Holiday",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D4Overtime",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D4Regular",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D4Vacation",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D5Holiday",
                table: "TimeSheets");

            migrationBuilder.RenameColumn(
                name: "D6Vacation",
                table: "TimeSheets",
                newName: "D6");

            migrationBuilder.RenameColumn(
                name: "D6Regular",
                table: "TimeSheets",
                newName: "D5");

            migrationBuilder.RenameColumn(
                name: "D6Overtime",
                table: "TimeSheets",
                newName: "D4");

            migrationBuilder.RenameColumn(
                name: "D6Holiday",
                table: "TimeSheets",
                newName: "D3");

            migrationBuilder.RenameColumn(
                name: "D5Vacation",
                table: "TimeSheets",
                newName: "D2");

            migrationBuilder.RenameColumn(
                name: "D5Regular",
                table: "TimeSheets",
                newName: "D1");

            migrationBuilder.RenameColumn(
                name: "D5Overtime",
                table: "TimeSheets",
                newName: "D0");
        }
    }
}
