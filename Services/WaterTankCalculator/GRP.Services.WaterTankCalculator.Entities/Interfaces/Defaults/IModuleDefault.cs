using GRP.Core.Interfaces;

namespace GRP.Services.WaterTankCalculator.Entities.Interfaces.Defaults;

public interface IModuleDefault : IEntityBase,IDefaultEntitiy
{
    public string? Name { get; set; }
    public float Weight { get; set; }
    public string? Dimensions { get; set; }
    public string? Type { get; set; }
    public int TotalOrders { get; set; }
}
