using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TabelGPWebAPI.Migrations
{
    public partial class AddReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MachineId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateReport = table.Column<string>(type: "text", nullable: true),
                    NumShiftReport = table.Column<string>(type: "text", nullable: true),
                    PercentOfReport = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Report_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerReport_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerReport_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    AmountPiecesDone = table.Column<float>(type: "real", nullable: false),
                    StartWorkTime = table.Column<string>(type: "text", nullable: true),
                    EndWorkTime = table.Column<string>(type: "text", nullable: true),
                    GroupDifficulty = table.Column<float>(type: "real", nullable: false),
                    NameOrder = table.Column<string>(type: "text", nullable: true),
                    NumOrder = table.Column<string>(type: "text", nullable: true),
                    TypeWork = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkReport_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Report_AppUserId",
                table: "Report",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_MachineId",
                table: "Report",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerReport_EmployeeId",
                table: "WorkerReport",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerReport_ReportId",
                table: "WorkerReport",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkReport_ReportId",
                table: "WorkReport",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkerReport");

            migrationBuilder.DropTable(
                name: "WorkReport");

            migrationBuilder.DropTable(
                name: "Report");
        }
    }
}