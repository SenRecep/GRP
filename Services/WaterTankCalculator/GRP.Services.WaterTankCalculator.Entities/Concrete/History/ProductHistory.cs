#nullable disable
using GRP.Core.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.History;

public class ProductHistory:EntityBase
{
    public float Quantity { get; set; }
    public float Cost { get; set; }

    public string ProductDefaultKey{ get; set; }
    public virtual ProductDefault ProductDefault{ get; set; }

    public Guid? CalculateModelHistoryId { get; set; }
    public virtual CalculateModelHistory CalculateModelHistory { get; set; }
}
