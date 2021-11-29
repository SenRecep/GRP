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
    public virtual ModuleDefault ModuleDefault { get; set; }

    public Guid? CalculateModelHistoryId { get; set; }
    public virtual CalculateModelHistory CalculateModelHistory { get; set; }
}
