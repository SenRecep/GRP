#nullable disable
using GRP.Core.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Enums;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.History;

public class CalculationHistory : EntityBase
{
    public virtual IEnumerable<CalculateModelHistory> CalculateModelHistories { get; set; }

    public Guid? CompnyId { get; set; }
    public PaymentType PaymentType { get; set; }

    public float Total { get; set; }
    public float KDV { get; set; }
    public float FullTotal { get; set; }


    public Guid? ConstantsHistoryId { get; set; }
    public virtual ConstantsHistory ConstantsHistory { get; set; }
}
