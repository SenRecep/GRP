#nullable disable
namespace GRP.Services.WaterTankCalculator.BLL.Models;

public record Exchange
{
    public ForeignCurrency USD { get; set; }
    public ForeignCurrency EUR { get; set; }
    public ForeignCurrency GBP { get; set; }
}
public class ForeignCurrency
{
    public string Satis { get; set; }
    public string Alis { get; set; }
    public string Degisim { get; set; }
}
