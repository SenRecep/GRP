using GRP.Services.WaterTankCalculator.Entities.Enums;

namespace GRP.Services.WaterTankCalculator.BLL.Models;

public record Tank()
{
    public string? Type { get; set; }
    public float Capacity { get; set; }
    public float Width { get; set; }
    public float Length { get; set; }
    public float Height { get; set; }
    public int Quantity { get; set; }
    public float Total { get; set; }
    public float FullTotal { get; set; }
    public PaymentType PaymentType { get; set; }

}

public class CalculateHistoryResponse
{
    public Guid Id { get; set; }
    public IEnumerable<Tank>? Tanks { get; set; }
    public string? Company { get; set; }

    public float Total { get; set; }
    public float KDV { get; set; }
    public float FullTotal { get; set; }
    public ConstantsModel? Constants { get; set; }
}



public class CalculateHistoryWithDateResponse: CalculateHistoryResponse
{
    public DateTime Time { get; set; }
}
