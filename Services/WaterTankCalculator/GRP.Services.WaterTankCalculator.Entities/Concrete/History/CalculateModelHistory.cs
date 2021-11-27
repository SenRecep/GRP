#nullable disable
using GRP.Core.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Enums;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.History;

public class CalculateModelHistory:EntityBase
{
    public float Width { get; set; }
    public float Length { get; set; }
    public float Height { get; set; }
    public PlinthType PlinthType { get; set; }

    public Guid CalculationHistoryId { get; set; }
    public CalculationHistory CalculationHistory { get; set; }
}
