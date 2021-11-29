using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRP.Services.WaterTankCalculator.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Constants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    GRPKgPrice = table.Column<float>(type: "real", nullable: false),
                    Transportation = table.Column<float>(type: "real", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstantsHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    GRPKgPrice = table.Column<float>(type: "real", nullable: false),
                    Dollar = table.Column<float>(type: "real", nullable: false),
                    Transportation = table.Column<float>(type: "real", nullable: false),
                    CalculationHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstantsHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleDefaults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalOrders = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleDefaults", x => x.Id);
                    table.UniqueConstraint("AK_ModuleDefaults_Key", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "ProductDefaults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDefaults", x => x.Id);
                    table.UniqueConstraint("AK_ProductDefaults_Key", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "RATDefaults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    DKPS = table.Column<float>(type: "real", nullable: false),
                    LC = table.Column<float>(type: "real", nullable: false),
                    DIP = table.Column<float>(type: "real", nullable: false),
                    RUB = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RATDefaults", x => x.Id);
                    table.UniqueConstraint("AK_RATDefaults_Key", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "CalculationHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ConstantsHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_CalculationHistories_ConstantsHistories_ConstantsHistoryId",
                        column: x => x.ConstantsHistoryId,
                        principalTable: "ConstantsHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CalculateModelHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    PlinthType = table.Column<int>(type: "int", nullable: false),
                    EdgeModelHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalCostHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CalculationHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculateModelHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculateModelHistories_CalculationHistories_CalculationHistoryId",
                        column: x => x.CalculationHistoryId,
                        principalTable: "CalculationHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EdgeModelHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Capacity = table.Column<float>(type: "real", nullable: false),
                    Edge_Top = table.Column<float>(type: "real", nullable: false),
                    Edge_Bottom = table.Column<float>(type: "real", nullable: false),
                    Edge_Side = table.Column<float>(type: "real", nullable: false),
                    Interior_Top = table.Column<float>(type: "real", nullable: false),
                    Interior_Bottom = table.Column<float>(type: "real", nullable: false),
                    Interior_Side = table.Column<float>(type: "real", nullable: false),
                    Outside_Top = table.Column<float>(type: "real", nullable: false),
                    Outside_Bottom = table.Column<float>(type: "real", nullable: false),
                    Outside_Side = table.Column<float>(type: "real", nullable: false),
                    CalculateModelHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdgeModelHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EdgeModelHistories_CalculateModelHistories_CalculateModelHistoryId",
                        column: x => x.CalculateModelHistoryId,
                        principalTable: "CalculateModelHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ModuleHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    TotalOrders = table.Column<int>(type: "int", nullable: false),
                    TotalWeight = table.Column<float>(type: "real", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    ModuleDefaultKey = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CalculateModelHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleHistories_CalculateModelHistories_CalculateModelHistoryId",
                        column: x => x.CalculateModelHistoryId,
                        principalTable: "CalculateModelHistories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModuleHistories_ModuleDefaults_ModuleDefaultKey",
                        column: x => x.ModuleDefaultKey,
                        principalTable: "ModuleDefaults",
                        principalColumn: "Key");
                });

            migrationBuilder.CreateTable(
                name: "ProductHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    ProductDefaultKey = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CalculateModelHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductHistories_CalculateModelHistories_CalculateModelHistoryId",
                        column: x => x.CalculateModelHistoryId,
                        principalTable: "CalculateModelHistories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductHistories_ProductDefaults_ProductDefaultKey",
                        column: x => x.ProductDefaultKey,
                        principalTable: "ProductDefaults",
                        principalColumn: "Key");
                });

            migrationBuilder.CreateTable(
                name: "RATHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    RATDefaultKey = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CalculateModelHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RATHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RATHistories_CalculateModelHistories_CalculateModelHistoryId",
                        column: x => x.CalculateModelHistoryId,
                        principalTable: "CalculateModelHistories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RATHistories_RATDefaults_RATDefaultKey",
                        column: x => x.RATDefaultKey,
                        principalTable: "RATDefaults",
                        principalColumn: "Key");
                });

            migrationBuilder.CreateTable(
                name: "TotalCostHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Subtotal = table.Column<float>(type: "real", nullable: false),
                    Financing = table.Column<float>(type: "real", nullable: false),
                    GoesInvisible = table.Column<float>(type: "real", nullable: false),
                    GrandTotal = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    CalculateModelHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalCostHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TotalCostHistories_CalculateModelHistories_CalculateModelHistoryId",
                        column: x => x.CalculateModelHistoryId,
                        principalTable: "CalculateModelHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalculateModelHistories_CalculationHistoryId",
                table: "CalculateModelHistories",
                column: "CalculationHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CalculationHistories_ConstantsHistoryId",
                table: "CalculationHistories",
                column: "ConstantsHistoryId",
                unique: true,
                filter: "[ConstantsHistoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EdgeModelHistories_CalculateModelHistoryId",
                table: "EdgeModelHistories",
                column: "CalculateModelHistoryId",
                unique: true,
                filter: "[CalculateModelHistoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleHistories_CalculateModelHistoryId",
                table: "ModuleHistories",
                column: "CalculateModelHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleHistories_ModuleDefaultKey",
                table: "ModuleHistories",
                column: "ModuleDefaultKey");

            migrationBuilder.CreateIndex(
                name: "IX_ProductHistories_CalculateModelHistoryId",
                table: "ProductHistories",
                column: "CalculateModelHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductHistories_ProductDefaultKey",
                table: "ProductHistories",
                column: "ProductDefaultKey");

            migrationBuilder.CreateIndex(
                name: "IX_RATHistories_CalculateModelHistoryId",
                table: "RATHistories",
                column: "CalculateModelHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RATHistories_RATDefaultKey",
                table: "RATHistories",
                column: "RATDefaultKey");

            migrationBuilder.CreateIndex(
                name: "IX_TotalCostHistories_CalculateModelHistoryId",
                table: "TotalCostHistories",
                column: "CalculateModelHistoryId",
                unique: true,
                filter: "[CalculateModelHistoryId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Constants");

            migrationBuilder.DropTable(
                name: "EdgeModelHistories");

            migrationBuilder.DropTable(
                name: "ModuleHistories");

            migrationBuilder.DropTable(
                name: "ProductHistories");

            migrationBuilder.DropTable(
                name: "RATHistories");

            migrationBuilder.DropTable(
                name: "TotalCostHistories");

            migrationBuilder.DropTable(
                name: "ModuleDefaults");

            migrationBuilder.DropTable(
                name: "ProductDefaults");

            migrationBuilder.DropTable(
                name: "RATDefaults");

            migrationBuilder.DropTable(
                name: "CalculateModelHistories");

            migrationBuilder.DropTable(
                name: "CalculationHistories");

            migrationBuilder.DropTable(
                name: "ConstantsHistories");
        }
    }
}
