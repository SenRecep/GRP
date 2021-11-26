#nullable disable
using GRP.Core.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.History;

public class RATHistory : EntityBase
{
    public float Quantity { get; set; }
    public float Cost { get; set; }

    public string RATDefaultKey { get; set; }
    public RATDefault RATDefault { get; set; }
}
