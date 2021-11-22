namespace GRP.Services.WaterTankCalculator.BLL.Models;
#nullable disable
public record RATGroup
{
    public RAT TLG { get; set; }
    public RAT DGKG { get; set; }
    public RAT DGBG { get; set; }
    public RAT K1G { get; set; }
    public RAT IGK { get; set; }
    public RAT M12GT { get; set; }
    public float TotalCost { get; set; }
}
