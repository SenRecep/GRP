#nullable disable
using GRP.Core.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Enums;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.History;

public class CalculationHistory : EntityBase
{
    public float Width { get; set; }
    public float Length { get; set; }
    public float Height { get; set; }
    public PlinthType PlinthType { get; set; }

    public Guid ConstantsHistoryId { get; set; }
    public ConstantsHistory ConstantsHistory { get; set; }
}
