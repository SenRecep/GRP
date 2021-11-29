using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class TotalCostManager : ITotalCostService
{
    public TotalCost TotalCostCalculate(TotalCost totalCost, ModuleGroup moduleGroup, ProductGroup productGroup, RATGroup ratGroup, ConstantsModel constants)
    {
        totalCost.Subtotal = moduleGroup.TotalCost + productGroup.TotalCost + ratGroup.TotalCost;
        totalCost.Financing = totalCost.Subtotal * 0.03f;
        totalCost.GoesInvisible = totalCost.Subtotal * 0.02f;
        totalCost.GrandTotal = totalCost.Subtotal + totalCost.Financing + totalCost.GoesInvisible;
        totalCost.Total = constants.Transportation + totalCost.GrandTotal;
        return totalCost;
    }
}
