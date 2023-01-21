using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPA.Data.Migrations
{
    public partial class employeeAndTimesheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    FedTax = table.Column<double>(type: "float", nullable: false),
                    ProvTax = table.Column<double>(type: "float", nullable: false),
                    RRQ = table.Column<double>(type: "float", nullable: false),
                    RQAP = table.Column<double>(type: "float", nullable: false),
                    Vacation = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WeekDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    D1 = table.Column<double>(type: "float", nullable: false),
                    D2 = table.Column<double>(type: "float", nullable: false),
                    D3 = table.Column<double>(type: "float", nullable: false),
                    D4 = table.Column<double>(type: "float", nullable: false),
                    D5 = table.Column<double>(type: "float", nullable: false),
                    Tasks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheets_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_EmployeeId",
                table: "TimeSheets",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSheets");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
