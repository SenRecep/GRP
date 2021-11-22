using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Shared.Core.ExtensionMethods;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public abstract class ModuleManager : IModuleService
{
    public ModuleGroup ModulesCalculate(ModuleGroup moduleGroup, CalculateModel calculateModel, Capacity capacity, Constants constants)
    {
        YIC19(moduleGroup.YIC19);
        YIC21(moduleGroup.YIC21, calculateModel, capacity);
        YIC25(moduleGroup.YIC25, calculateModel, capacity);
        YIC22(moduleGroup.YIC22);
        YIC28(moduleGroup.YIC28, calculateModel);
        YIC13(moduleGroup.YIC13, calculateModel);
        ADTT(moduleGroup.ADTT, calculateModel);
        ATB(moduleGroup.ATB,calculateModel);
        ADBTT(moduleGroup.ADBTT);
        UDB22(moduleGroup.UDB22);
        UDB13(moduleGroup.UDB13);
        moduleGroup.GetType().GetProperties().ToList().ForEach(x =>
        {
            if (x.PropertyType != typeof(Module)) return;
            var module = x.GetValue(moduleGroup).Cast<Module>();
            if (module == null) return;
            module.TotalWeight = module.Weight * module.TotalOrders;
            module.Cost = module.TotalWeight * constants.GRPKgPrice;
            moduleGroup.TotalCost += module.Cost;
            moduleGroup.TotalWeight += module.TotalWeight;
        });
        return moduleGroup;
    }
    protected virtual Module YIC19(Module module) => module;
    protected virtual Module ADBTT(Module module) => module;
    protected virtual Module UDB22(Module module) => module;
    protected virtual Module UDB13(Module module) => module;
    protected virtual Module YIC22(Module module) => module;
    protected virtual Module YIC13(Module module, CalculateModel calculateModel)
    {
        if (module.IsNull()) return module;
        module.TotalOrders = (calculateModel.Width != calculateModel.Width.Int() ?
            calculateModel.Height * 2 + calculateModel.Length * 2 :
            calculateModel.Length != calculateModel.Length.Int() ?
            calculateModel.Height * 2 + calculateModel.Width * 2 : 0).Int();
        return module;
    }
    protected abstract Module YIC21(Module module, CalculateModel calculateModel, Capacity capacity);
    protected abstract Module YIC25(Module module, CalculateModel calculateModel, Capacity capacity);
    protected abstract Module YIC28(Module module, CalculateModel calculateModel);
    protected abstract Module ADTT(Module module, CalculateModel calculateModel);
    protected abstract Module ATB(Module module, CalculateModel calculateModel);
   

}
