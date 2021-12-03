using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRP.Services.WaterTankCalculator.Migrations
{
    public partial class PaymentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "CalculationHistories");

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "CalculateModelHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "CalculateModelHistories");

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "CalculationHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
