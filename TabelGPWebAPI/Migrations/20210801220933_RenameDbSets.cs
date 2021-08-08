using Microsoft.EntityFrameworkCore.Migrations;

namespace TabelGPWebAPI.Migrations
{
    public partial class RenameDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_Machines_MachineId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_Users_AppUserId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerReport_Employees_EmployeeId",
                table: "WorkerReport");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerReport_Report_ReportId",
                table: "WorkerReport");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkReport_Report_ReportId",
                table: "WorkReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkReport",
                table: "WorkReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkerReport",
                table: "WorkerReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                table: "Report");

            migrationBuilder.RenameTable(
                name: "WorkReport",
                newName: "WorkReports");

            migrationBuilder.RenameTable(
                name: "WorkerReport",
                newName: "WorkerReports");

            migrationBuilder.RenameTable(
                name: "Report",
                newName: "Reports");

            migrationBuilder.RenameIndex(
                name: "IX_WorkReport_ReportId",
                table: "WorkReports",
                newName: "IX_WorkReports_ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerReport_ReportId",
                table: "WorkerReports",
                newName: "IX_WorkerReports_ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerReport_EmployeeId",
                table: "WorkerReports",
                newName: "IX_WorkerReports_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Report_MachineId",
                table: "Reports",
                newName: "IX_Reports_MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_Report_AppUserId",
                table: "Reports",
                newName: "IX_Reports_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkReports",
                table: "WorkReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkerReports",
                table: "WorkerReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Machines_MachineId",
                table: "Reports",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_AppUserId",
                table: "Reports",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerReports_Employees_EmployeeId",
                table: "WorkerReports",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerReports_Reports_ReportId",
                table: "WorkerReports",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkReports_Reports_ReportId",
                table: "WorkReports",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Machines_MachineId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_AppUserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerReports_Employees_EmployeeId",
                table: "WorkerReports");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerReports_Reports_ReportId",
                table: "WorkerReports");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkReports_Reports_ReportId",
                table: "WorkReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkReports",
                table: "WorkReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkerReports",
                table: "WorkerReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.RenameTable(
                name: "WorkReports",
                newName: "WorkReport");

            migrationBuilder.RenameTable(
                name: "WorkerReports",
                newName: "WorkerReport");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "Report");

            migrationBuilder.RenameIndex(
                name: "IX_WorkReports_ReportId",
                table: "WorkReport",
                newName: "IX_WorkReport_ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerReports_ReportId",
                table: "WorkerReport",
                newName: "IX_WorkerReport_ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerReports_EmployeeId",
                table: "WorkerReport",
                newName: "IX_WorkerReport_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_MachineId",
                table: "Report",
                newName: "IX_Report_MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_AppUserId",
                table: "Report",
                newName: "IX_Report_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkReport",
                table: "WorkReport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkerReport",
                table: "WorkerReport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                table: "Report",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Machines_MachineId",
                table: "Report",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Users_AppUserId",
                table: "Report",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerReport_Employees_EmployeeId",
                table: "WorkerReport",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerReport_Report_ReportId",
                table: "WorkerReport",
                column: "ReportId",
                principalTable: "Report",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkReport_Report_ReportId",
                table: "WorkReport",
                column: "ReportId",
                principalTable: "Report",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}