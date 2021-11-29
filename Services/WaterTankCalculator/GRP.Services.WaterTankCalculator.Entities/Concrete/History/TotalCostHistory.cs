#nullable disable
using GRP.Core.Concrete;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.History;

public class TotalCostHistory:EntityBase
{
    public float Subtotal { get; set; }
    public float Financing { get; set; }
    public float GoesInvisible { get; set; }
    public float GrandTotal { get; set; }
    public float Total { get; set; }
    public float FullTotal { get; set; }


    public Guid? CalculateModelHistoryId { get; set; }
    public virtual CalculateModelHistory CalculateModelHistory { get; set; }

}
