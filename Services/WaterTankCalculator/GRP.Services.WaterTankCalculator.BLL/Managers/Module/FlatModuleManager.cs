using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Shared.Core.ExtensionMethods;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class FlatModuleManager : ModuleManager, IFlatModuleService
{
    protected override Module ADTT(Module module, CalculateModel calculateModel)
    {
        if (module.IsNull()) return module;
        module.TotalOrders = ((MathF.Floor(calculateModel.Width) * MathF.Floor(calculateModel.Length)) * 2 - 1).Int();
        return module;
    }
    protected override Module ATB(Module module, CalculateModel calculateModel)
    {
        return module;
    }
    protected override Module YIC21(Module module, CalculateModel calculateModel, Capacity capacity)
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
    protected override Module YIC25(Module module, CalculateModel calculateModel, Capacity capacity)
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
    protected override Module YIC28(Module module, CalculateModel calculateModel)
    {
        if (module.IsNull()) return module;
        module.TotalOrders = calculateModel.Height is 1.5f or 2.5f ?
            (int)(MathF.Floor(calculateModel.Width) + MathF.Floor(calculateModel.Length)) * 2 : 0;
        return module;
    }
}
