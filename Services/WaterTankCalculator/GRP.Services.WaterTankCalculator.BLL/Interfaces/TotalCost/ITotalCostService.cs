using GRP.Services.WaterTankCalculator.BLL.Models;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces;

public interface ITotalCostService
{
    TotalCost TotalCostCalculate(TotalCost totalCost, ModuleGroup moduleGroup, ProductGroup productGroup, RATGroup ratGroup, ConstantsModel constants);
}
