using GRP.Core.Interfaces;

namespace GRP.Services.WaterTankCalculator.BLL.Models.DTO;

public class ModuleDto:IDTO
{
    public Guid Id { get; set; }
    public string? Key { get; set; }
    public string? Name { get; set; }
    public float Weight { get; set; }
    public string? Dimensions { get; set; }
    public string? Type { get; set; }
    public int TotalOrders { get; set; }
}
