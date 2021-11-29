using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRP.Services.WaterTankCalculator.Migrations
{
    public partial class history_fulltota_kdv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "FullTotal",
                table: "TotalCostHistories",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "FullTotal",
                table: "CalculationHistories",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "KDV",
                table: "CalculationHistories",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "CalculationHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CalculateModelHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullTotal",
                table: "TotalCostHistories");

            migrationBuilder.DropColumn(
                name: "FullTotal",
                table: "CalculationHistories");

            migrationBuilder.DropColumn(
                name: "KDV",
                table: "CalculationHistories");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "CalculationHistories");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CalculateModelHistories");
        }
    }
}
