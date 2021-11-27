#nullable disable
using GRP.Core.Concrete;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.History;

public class TotalCostHistory:EntityBase
{
    public float Subtotal { get; set; }
    public float Financing { get; set; }
    public float GoesInvisible { get; set; }
    public float GrandTotal { get; set; }
    public float IntercityTransportation { get; set; }
    public float Total { get; set; }

    public Guid CalculationHistoryId { get; set; }
    public CalculationHistory CalculationHistory { get; set; }

}
