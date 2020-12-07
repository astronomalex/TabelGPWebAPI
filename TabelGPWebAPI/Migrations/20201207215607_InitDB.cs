using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TabelGPWebAPI.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Norms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Machine = table.Column<string>(nullable: false),
                    GroupDiff = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Norms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateReport = table.Column<string>(nullable: true),
                    Machine = table.Column<string>(nullable: true),
                    NumSmenReport = table.Column<string>(nullable: true),
                    PersentOfReport = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Smens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    DateSmen = table.Column<string>(nullable: false),
                    Machine = table.Column<string>(nullable: false),
                    NumSmen = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkerDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    TableNum = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkerReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TbNum = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    ReportId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerReport_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartWorkTime = table.Column<string>(nullable: true),
                    EndWorkTime = table.Column<string>(nullable: true),
                    TypeWork = table.Column<string>(nullable: true),
                    NumOrder = table.Column<string>(nullable: true),
                    NameOrder = table.Column<string>(nullable: true),
                    GroupDifficulty = table.Column<string>(nullable: true),
                    AmountDonePieces = table.Column<int>(nullable: false),
                    ReportId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkUnits_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    TbNum = table.Column<string>(nullable: false),
                    Grade = table.Column<string>(nullable: false),
                    SdelTime = table.Column<float>(nullable: false),
                    NightTime = table.Column<float>(nullable: false),
                    ProstTime = table.Column<float>(nullable: false),
                    PrikTime = table.Column<float>(nullable: false),
                    SrednTime = table.Column<float>(nullable: false),
                    PprTime = table.Column<float>(nullable: false),
                    DoubleTime = table.Column<float>(nullable: false),
                    SmenaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerTimes_Smens_SmenaId",
                        column: x => x.SmenaId,
                        principalTable: "Smens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkerReport_ReportId",
                table: "WorkerReport",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerTimes_SmenaId",
                table: "WorkerTimes",
                column: "SmenaId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkUnits_ReportId",
                table: "WorkUnits",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Norms");

            migrationBuilder.DropTable(
                name: "WorkerDatas");

            migrationBuilder.DropTable(
                name: "WorkerReport");

            migrationBuilder.DropTable(
                name: "WorkerTimes");

            migrationBuilder.DropTable(
                name: "WorkUnits");

            migrationBuilder.DropTable(
                name: "Smens");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
