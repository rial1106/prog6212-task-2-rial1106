using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROG6212.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    moduleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    moduleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    credits = table.Column<int>(type: "int", nullable: false),
                    classHoursPerWeek = table.Column<double>(type: "float", nullable: false),
                    hoursStudiedToday = table.Column<double>(type: "float", nullable: true),
                    hoursStudiedThisWeek = table.Column<double>(type: "float", nullable: true),
                    semesterNumOfWeeks = table.Column<int>(type: "int", nullable: false),
                    semesterStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    username = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.moduleCode);
                    table.ForeignKey(
                        name: "FK_modules_users_username",
                        column: x => x.username,
                        principalTable: "users",
                        principalColumn: "username");
                });

            migrationBuilder.CreateTable(
                name: "studyDates",
                columns: table => new
                {
                    StudyDateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hoursStudied = table.Column<double>(type: "float", nullable: false),
                    moduleCode = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studyDates", x => x.StudyDateID);
                    table.ForeignKey(
                        name: "FK_studyDates_modules_moduleCode",
                        column: x => x.moduleCode,
                        principalTable: "modules",
                        principalColumn: "moduleCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_modules_username",
                table: "modules",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "IX_studyDates_moduleCode",
                table: "studyDates",
                column: "moduleCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studyDates");

            migrationBuilder.DropTable(
                name: "modules");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
