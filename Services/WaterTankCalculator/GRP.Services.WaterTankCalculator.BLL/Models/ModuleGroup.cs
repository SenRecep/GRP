namespace GRP.Services.WaterTankCalculator.BLL.Models;

#nullable disable
using GRP.Shared.Core.ExtensionMethods;

public record ModuleGroup
{
    public Module YIC19 { get; set; }
    public Module YIC21 { get; set; }
    public Module YIC25 { get; set; }
    public Module YIC22 { get; set; }
    public Module YIC28 { get; set; }
    public Module YIC13 { get; set; }
    public Module ADTT { get; set; }
    public Module ADBTT { get; set; }
    public Module ATB { get; set; }
    public Module UDB22 { get; set; }
    public Module UDB13 { get; set; }
    public float TotalWeight { get; set; }   
    public float TotalCost { get; set; }   
    public List<Module> Modules()
    {
        return GetType().GetProperties().ToList().Select(p =>
        {
            if (p.PropertyType != typeof(Module)) return null;
            Module module = p.GetValue(this).Cast<Module>();
            return module;
        }).Where(x => x.IsNotNull()).ToList();
    }
}
