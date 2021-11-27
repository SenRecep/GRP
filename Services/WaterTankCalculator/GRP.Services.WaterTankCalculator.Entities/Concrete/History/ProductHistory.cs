#nullable disable
using GRP.Core.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.History;

public class ProductHistory:EntityBase
{
    public float Quantity { get; set; }
    public float Cost { get; set; }

    public string ProductDefaultKey{ get; set; }
    public ProductDefault ProductDefault{ get; set; }

    public Guid CalculationHistoryId { get; set; }
    public CalculationHistory CalculationHistory { get; set; }
}
