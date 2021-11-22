namespace GRP.Services.WaterTankCalculator.BLL.Models;

#nullable disable
public record ProductGroup
{
    public Product FM { get; set; }
    public Product MM { get; set; }
    public Product C360 { get; set; }
    public Product M1045GC { get; set; }
    public Product M1045GS { get; set; }
    public Product M1045GP { get; set; }
    public Product M1045PC { get; set; }
    public Product M10PS { get; set; }
    public Product M10PP { get; set; }
    public Product M1045KC { get; set; }
    public Product M12120PGS { get; set; }
    public Product M12GS { get; set; }
    public Product M12GGP { get; set; }
    public Product M12US { get; set; }
    public Product M12PS { get; set; }
    public Product DBS { get; set; }
    public Product G502 { get; set; }
    public Product DBRP { get; set; }
    public Product DBRPVC { get; set; }
    public Product SGM { get; set; }
    public Product DMG { get; set; }
    public Product DMP { get; set; }
    public Product IM { get; set; }
    public Product PPRCD { get; set; }
    public Product PK { get; set; }
    public float TotalCost { get; set; }
}