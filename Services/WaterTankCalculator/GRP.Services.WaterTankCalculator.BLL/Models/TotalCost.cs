namespace GRP.Services.WaterTankCalculator.BLL.Models;
public record TotalCost
{
    public float Subtotal { get; set; }
    public float Financing { get; set; }
    public float GoesInvisible { get; set; }
    public float GrandTotal { get; set; }
    public float IntercityTransportation { get; set; }
    public float Total { get; set; }
}
