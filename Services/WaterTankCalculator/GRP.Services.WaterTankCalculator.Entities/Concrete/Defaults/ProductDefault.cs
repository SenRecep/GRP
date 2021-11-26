using GRP.Core.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Concrete.History;
using GRP.Services.WaterTankCalculator.Entities.Interfaces.Defaults;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;

public class ProductDefault:EntityBase,IProductDefault
{
    public string? Key { get; set; }
    public string? Name { get; set; }
    public float UnitPrice { get; set; }
    public float Quantity { get; set; }

    public IEnumerable<ProductHistory> ProductHistories { get; set; }

}
