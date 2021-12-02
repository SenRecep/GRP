using GRP.Core.Interfaces;

namespace GRP.Services.WaterTankCalculator.BLL.Models.DTO;

public class RATDto:IDTO
{
    public Guid Id { get; set; }    
    public string? Key { get; set; }
    public string? Name { get; set; }
    public float Weight { get; set; }
    public float DKPS { get; set; }
    public float LC { get; set; }
    public float DIP { get; set; }
    public float RUB { get; set; }
    public float Quantity { get; set; }
}
