using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Shared.Core.ExtensionMethods;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class ModuleManager : IModuleService
{
    public ModuleGroup ModulesCalculate(ModuleGroup moduleGroup, CalculateModel calculateModel, Capacity capacity, Constants constants)
    {
        YIC19(moduleGroup.YIC19, calculateModel, capacity);
        YIC21(moduleGroup.YIC21, calculateModel, capacity);
        YIC25(moduleGroup.YIC25, calculateModel, capacity);
        YIC22(moduleGroup.YIC22, calculateModel, capacity);
        YIC28(moduleGroup.YIC28, calculateModel, capacity);
        YIC13(moduleGroup.YIC13, calculateModel, capacity);
        ADTT(moduleGroup.ADTT, calculateModel, capacity);
        ATB(moduleGroup.ATB, calculateModel, capacity);
        ADBTT(moduleGroup.ADBTT, calculateModel, capacity);
        UDB22(moduleGroup.UDB22, calculateModel, capacity);
        UDB13(moduleGroup.UDB13, calculateModel, capacity);
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
    private Module YIC19(Module module, CalculateModel calculateModel, Capacity capacity)
    {
        return module;
    }
    private Module YIC21(Module module, CalculateModel calculateModel, Capacity capacity)
    {
        if (module.IsNull()) return module;
        if (calculateModel.Height is not 1.5f && (capacity.Value is < 8 || calculateModel.Height is 1 or 2 or 3 or 4))
        {
            module.TotalOrders = (calculateModel.Width.Int() + calculateModel.Length.Int()) * 2;
            if (capacity.Value is < 8 && calculateModel.Height is 2 or 3 or 4) module.TotalOrders *= 2;
            return module;
        }
        module.TotalOrders = 0;
        return module;
    }
    private Module YIC25(Module module, CalculateModel calculateModel, Capacity capacity)
    {
        if (module.IsNull()) return module;
        if (capacity.Value >= 8 && calculateModel.Height is 2 or 2.5f or 3)
        {
            module.TotalOrders = (calculateModel.Width.Int() + calculateModel.Length.Int()) * 2;
            if (calculateModel.Height is 3)
                module.TotalOrders *= 2;
            return module;
        }
        module.TotalOrders = 0;
        return module;
    }
    private Module YIC22(Module module, CalculateModel calculateModel, Capacity capacity)
    {
        return module;
    }
    private Module YIC28(Module module, CalculateModel calculateModel, Capacity capacity)
    {
        if (module.IsNull()) return module;
        module.TotalOrders = calculateModel.Height is 1.5f or 2.5f ?
            (int)(MathF.Floor(calculateModel.Width) + MathF.Floor(calculateModel.Length)) * 2 : 0;
        return module;
    }
    private Module YIC13(Module module, CalculateModel calculateModel, Capacity capacity)
    {
        if (module.IsNull()) return module;
        module.TotalOrders = (calculateModel.Width != calculateModel.Width.Int() ?
            calculateModel.Height * 2 + calculateModel.Length * 2 :
            calculateModel.Length != calculateModel.Length.Int() ?
            calculateModel.Height * 2 + calculateModel.Width * 2:0).Int();
        return module;
    }
    private Module ADTT(Module module, CalculateModel calculateModel, Capacity capacity)
    {
        if (module.IsNull()) return module;
        module.TotalOrders = ((MathF.Floor(calculateModel.Width)* MathF.Floor(calculateModel.Length)) *2-1).Int();
        return module;
    }
    private Module ATB(Module module, CalculateModel calculateModel, Capacity capacity)
    {
        return module;
    }
    private Module ADBTT(Module module, CalculateModel calculateModel, Capacity capacity)
    {
        return module;
    }
    private Module UDB22(Module module, CalculateModel calculateModel, Capacity capacity)
    {
        module.TotalOrders = 1;
        return module;
    }
    private Module UDB13(Module module, CalculateModel calculateModel, Capacity capacity)
    {
        module.TotalOrders = 1;
        return module;
    }
}
