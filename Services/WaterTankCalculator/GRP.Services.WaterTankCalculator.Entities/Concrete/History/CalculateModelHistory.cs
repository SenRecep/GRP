#nullable disable
using GRP.Core.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Enums;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.History;

public class CalculateModelHistory : EntityBase
{
    public float Width { get; set; }
    public float Length { get; set; }
    public float Height { get; set; }
    public int Quantity { get; set; }
    public PlinthType PlinthType { get; set; }

    public virtual IEnumerable<ProductHistory> ProductHistories { get; set; }
    public virtual IEnumerable<ModuleHistory> ModuleHistories { get; set; }
    public virtual IEnumerable<RATHistory> RATHistories { get; set; }


    public Guid? EdgeModelHistoryId { get; set; }
    public virtual EdgeModelHistory EdgeModelHistory { get; set; }

    public Guid? TotalCostHistoryId { get; set; }
    public virtual TotalCostHistory TotalCostHistory { get; set; }

    public Guid? CalculationHistoryId { get; set; }
    public virtual CalculationHistory CalculationHistory { get; set; }
}
