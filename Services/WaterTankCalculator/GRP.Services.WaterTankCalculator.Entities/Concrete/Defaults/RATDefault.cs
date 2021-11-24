using GRP.Core.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Interfaces.Defaults;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;

public class RATDefault:EntityBase,IRATDefault
{
    public string? Key { get; set; }
    public string? Name { get; set; }
    public float Weight { get; set; }
    public float DKPS { get; set; }
    public float LC { get; set; }
    public float DIP { get; set; }
    public float RUB { get; set; }
    public float Quantity { get; set; }
}
