using GRP.Core.Interfaces;

namespace GRP.Services.WaterTankCalculator.Entities.Interfaces.Defaults;

public interface IProductDefault:IEntityBase,IDefaultEntitiy
{
    public string? Name { get; set; }
    public float UnitPrice { get; set; }
    public float Quantity { get; set; }
}
