using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRP.Services.WaterTankCalculator.Migrations
{
    public partial class Histories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "RATDefaults",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "ProductDefaults",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "ModuleDefaults",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RATDefaults_Key",
                table: "RATDefaults",
                column: "Key");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProductDefaults_Key",
                table: "ProductDefaults",
                column: "Key");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ModuleDefaults_Key",
                table: "ModuleDefaults",
                column: "Key");

            migrationBuilder.CreateTable(
                name: "ModuleHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    TotalOrders = table.Column<int>(type: "int", nullable: false),
                    TotalWeight = table.Column<float>(type: "real", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    ModuleDefaultKey = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                        name: "FK_RATHistories_RATDefaults_RATDefaultKey",
                        column: x => x.RATDefaultKey,
                        principalTable: "RATDefaults",
                        principalColumn: "Key");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleHistories_ModuleDefaultKey",
                table: "ModuleHistories",
                column: "ModuleDefaultKey");

            migrationBuilder.CreateIndex(
                name: "IX_ProductHistories_ProductDefaultKey",
                table: "ProductHistories",
                column: "ProductDefaultKey");

            migrationBuilder.CreateIndex(
                name: "IX_RATHistories_RATDefaultKey",
                table: "RATHistories",
                column: "RATDefaultKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleHistories");

            migrationBuilder.DropTable(
                name: "ProductHistories");

            migrationBuilder.DropTable(
                name: "RATHistories");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RATDefaults_Key",
                table: "RATDefaults");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProductDefaults_Key",
                table: "ProductDefaults");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ModuleDefaults_Key",
                table: "ModuleDefaults");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "RATDefaults",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "ProductDefaults",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "ModuleDefaults",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
