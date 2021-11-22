namespace GRP.Services.WaterTankCalculator.BLL.Models;
public record RAT
{
    public string? Name { get; set; }
    public float Weight { get; set; }
    public float DKPS { get; set; }
    public float LC { get; set; }
    public float DIP { get; set; }
    public float RUB { get; set; }
    public float Quantity { get; set; }
    public float Cost { get; set; }

}
