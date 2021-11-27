#nullable disable
using GRP.Core.Concrete;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.History;

public class CalculationHistory : EntityBase
{
    public IEnumerable<CalculateModelHistory>CalculateModelHistories { get; set; }

    public Guid ConstantsHistoryId { get; set; }
    public ConstantsHistory ConstantsHistory { get; set; }

    public Guid ModuleHistoryId { get; set; }
    public ModuleHistory ModuleHistory { get; set; }

    public Guid ProductHistoryId { get; set; }
    public ProductHistory ProductHistory { get; set; }

    public Guid RATHistoryId { get; set; }
    public RATHistory RATHistory { get; set; }

    public Guid TotalCostHistoryId { get; set; }
    public TotalCostHistory TotalCostHistory { get; set; }
}
