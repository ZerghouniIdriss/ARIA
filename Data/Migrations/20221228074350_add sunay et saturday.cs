using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPA.Data.Migrations
{
    /// <inheritdoc />
    public partial class addsunayetsaturday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "D0",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "D6",
                table: "TimeSheets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "D0",
                table: "TimeSheets");

            migrationBuilder.DropColumn(
                name: "D6",
                table: "TimeSheets");
        }
    }
}
