using GRP.Core.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Concrete.History;
using GRP.Services.WaterTankCalculator.Entities.Interfaces.Defaults;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;

public class ModuleDefault : EntityBase,IModuleDefault
{
    public string? Key { get; set; }
    public string? Name { get; set; }
    public float Weight { get; set; }
    public string? Dimensions { get; set; }
    public string? Type { get; set; }
    public int TotalOrders { get; set; }
    public IEnumerable<ModuleHistory> ModuleHistories { get; set; }

}
