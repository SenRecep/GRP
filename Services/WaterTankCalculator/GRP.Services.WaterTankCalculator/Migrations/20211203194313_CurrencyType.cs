using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRP.Services.WaterTankCalculator.Migrations
{
    public partial class CurrencyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyType",
                table: "CalculationHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyType",
                table: "CalculationHistories");
        }
    }
}
