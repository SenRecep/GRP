namespace GRP.Services.WaterTankCalculator.BLL.Models;

public record Product
{
    public string? Name { get; set; }
    public float UnitPrice { get; set; }
    public float Quantity { get; set; }
    public float Cost { get; set; }
}
