using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Shared.Core.ExtensionMethods;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public abstract class RATManager : IRATService
{
    public RATGroup RATSCalculate(RATGroup group, CalculateModel calculateModel, Constants constants)
    {
        TLG(group.TLG, calculateModel, constants);
        DGKG(group.DGKG, calculateModel, constants);
        DGBG(group.DGBG, constants);
        K1G(group.K1G, calculateModel, constants);
        IGK(group.IGK, group.DGKG, constants);
        M12GT(group.M12GT, calculateModel, constants);
        group.GetType().GetProperties().ToList().ForEach(x =>
        {
            if (x.PropertyType != typeof(RAT)) return;
            var rat = x.GetValue(group).Cast<RAT>();
            if (rat == null) return;
            CostCalculate(rat, constants);
            group.TotalCost += rat.Cost;
        });
        return group;
    }
    protected virtual RAT CostCalculate(RAT rat, Constants constants)
    {
        rat.Cost = rat.Weight * (rat.DKPS + rat.LC + rat.DIP + rat.RUB) * rat.Quantity / constants.Dollar;
        return rat;
    }
    protected virtual RAT TLG(RAT rat, CalculateModel calculateModel, Constants constants)
    {
        var wpl = calculateModel.Width + calculateModel.Length;
        rat.Quantity = calculateModel.Height switch
        {
            1 or 1.5f or 2 => wpl * 2,
            2.5f => (wpl + MathF.Ceiling(wpl - 2)) * 2,
            _ => wpl * 4 + MathF.Ceiling(wpl - 2) * 6
        };
        return rat;
    }
    protected virtual RAT DGKG(RAT rat, CalculateModel calculateModel, Constants constants)
    {
        var wpl = calculateModel.Width + calculateModel.Length;
        var ru = MathF.Ceiling(wpl - 2);
        rat.Quantity = ru * 2;
        rat.Quantity *= calculateModel.Height switch
        {
            1 or 1.5f or 2 => 1,
            2.5f => 3,
            _ => 4
        };
        return rat;
    }
    protected virtual RAT DGBG(RAT rat, Constants constants)=> rat;
    protected virtual RAT K1G(RAT rat, CalculateModel calculateModel, Constants constants)
    {
        rat.Quantity = calculateModel.Height * 4;
        return rat;
    }
    protected virtual RAT IGK(RAT rat, RAT DGKG, Constants constants)
    {
        rat.Quantity = DGKG.Quantity;
        return rat;
    }
    protected virtual RAT M12GT(RAT rat, CalculateModel calculateModel, Constants constants)
    {
        rat.Quantity = MathF.Ceiling(calculateModel.Width - 1) * calculateModel.Length + MathF.Ceiling(calculateModel.Length - 1) * calculateModel.Width;
        rat.Quantity *= calculateModel.Height switch
        {
            1 or 1.5f or 2 => 1,
            2.5f => 3,
            _ => 4
        };
        return rat;
    }
}
