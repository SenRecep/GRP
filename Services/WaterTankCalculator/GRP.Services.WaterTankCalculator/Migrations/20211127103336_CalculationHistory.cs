using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRP.Services.WaterTankCalculator.Migrations
{
    public partial class CalculationHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CalculationHistoryId",
                table: "RATHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CalculationHistoryId",
                table: "ProductHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CalculationHistoryId",
                table: "ModuleHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ConstantsHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    GRPKgPrice = table.Column<float>(type: "real", nullable: false),
                    Dollar = table.Column<float>(type: "real", nullable: false),
                    IntercityTransportation = table.Column<float>(type: "real", nullable: false),
                    CalculationHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstantsHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TotalCostHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subtotal = table.Column<float>(type: "real", nullable: false),
                    Financing = table.Column<float>(type: "real", nullable: false),
                    GoesInvisible = table.Column<float>(type: "real", nullable: false),
                    GrandTotal = table.Column<float>(type: "real", nullable: false),
                    IntercityTransportation = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    CalculationHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalCostHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalculationHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ConstantsHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RATHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalCostHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculationHistories_ConstantsHistory_ConstantsHistoryId",
                        column: x => x.ConstantsHistoryId,
                        principalTable: "ConstantsHistory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalculationHistories_ModuleHistories_ConstantsHistoryId",
                        column: x => x.ConstantsHistoryId,
                        principalTable: "ModuleHistories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalculationHistories_ProductHistories_ConstantsHistoryId",
                        column: x => x.ConstantsHistoryId,
                        principalTable: "ProductHistories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalculationHistories_RATHistories_ConstantsHistoryId",
                        column: x => x.ConstantsHistoryId,
                        principalTable: "RATHistories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalculationHistories_TotalCostHistories_ConstantsHistoryId",
                        column: x => x.ConstantsHistoryId,
                        principalTable: "TotalCostHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CalculateModelHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    PlinthType = table.Column<int>(type: "int", nullable: false),
                    CalculationHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculateModelHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculateModelHistory_CalculationHistories_CalculationHistoryId",
                        column: x => x.CalculationHistoryId,
                        principalTable: "CalculationHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalculateModelHistory_CalculationHistoryId",
                table: "CalculateModelHistory",
                column: "CalculationHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CalculationHistories_ConstantsHistoryId",
                table: "CalculationHistories",
                column: "ConstantsHistoryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculateModelHistory");

            migrationBuilder.DropTable(
                name: "CalculationHistories");

            migrationBuilder.DropTable(
                name: "ConstantsHistory");

            migrationBuilder.DropTable(
                name: "TotalCostHistories");

            migrationBuilder.DropColumn(
                name: "CalculationHistoryId",
                table: "RATHistories");

            migrationBuilder.DropColumn(
                name: "CalculationHistoryId",
                table: "ProductHistories");

            migrationBuilder.DropColumn(
                name: "CalculationHistoryId",
                table: "ModuleHistories");
        }
    }
}
