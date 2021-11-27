#nullable disable
using GRP.Core.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.History;

public class ModuleHistory : EntityBase
{
    public int TotalOrders { get; set; }
    public float TotalWeight { get; set; }
    public float Cost { get; set; }

    public string ModuleDefaultKey { get; set; }
    public ModuleDefault ModuleDefault { get; set; }

    public Guid CalculationHistoryId { get; set; }
    public CalculationHistory CalculationHistory { get; set; }
}
