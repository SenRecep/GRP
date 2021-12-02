using GRP.Core.Interfaces;

namespace GRP.Services.WaterTankCalculator.BLL.Models.DTO;

public class ProductDto:IDTO
{
    public Guid Id { get; set; }
    public string? Key { get; set; }
    public string? Name { get; set; }
    public float UnitPrice { get; set; }
    public float Quantity { get; set; }

}
