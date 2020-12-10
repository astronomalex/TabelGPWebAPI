using Microsoft.EntityFrameworkCore.Migrations;

namespace TabelGPWebAPI.Migrations
{
    public partial class fixModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerTimes_Smens_SmenaId",
                table: "WorkerTimes");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerTimes_Smens_SmenaId",
                table: "WorkerTimes",
                column: "SmenaId",
                principalTable: "Smens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerTimes_Smens_SmenaId",
                table: "WorkerTimes");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerTimes_Smens_SmenaId",
                table: "WorkerTimes",
                column: "SmenaId",
                principalTable: "Smens",
                principalColumn: "Id");
        }
    }
}
