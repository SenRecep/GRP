using GRP.Core.Interfaces;

namespace GRP.Services.WaterTankCalculator.Entities.Interfaces.Defaults;

public interface IRATDefault:IEntityBase,IDefaultEntitiy
{
    string? Name { get; set; }
    float Weight { get; set; }
    float DKPS { get; set; }
    float LC { get; set; }
    float DIP { get; set; }
    float RUB { get; set; }
    float Quantity { get; set; }
}
