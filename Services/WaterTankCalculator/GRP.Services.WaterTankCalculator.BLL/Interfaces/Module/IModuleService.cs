using GRP.Services.WaterTankCalculator.BLL.Models;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces;
public interface IModuleService
{
    ModuleGroup ModulesCalculate(ModuleGroup moduleGroup, CalculateModel calculateModel, Capacity capacity,ConstantsModel constants);
}
