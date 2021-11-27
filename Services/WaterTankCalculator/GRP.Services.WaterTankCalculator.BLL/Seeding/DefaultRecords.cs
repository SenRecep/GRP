using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.BLL.Settings;
using GRP.Services.WaterTankCalculator.Entities.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;
using GRP.Shared.Core.ExtensionMethods;
using GRP.Shared.Core.StringInfo;

using Microsoft.Extensions.DependencyInjection;

namespace GRP.Services.WaterTankCalculator.BLL.Seeding;

public class DefaultRecords
{
    private readonly IServiceProvider serviceProvider;

    public DefaultRecords(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public Constants GetConstants()
    {
        var constants = serviceProvider.GetRequiredService<ConstantsSetting>() with { };
        var userId = Guid.Parse(SystemUserInfo.SystemUserId);
        return new()
        {
            CreatedUserId = userId,
            CreatedTime = DateTime.Now,
            GRPKgPrice=constants.GRPKgPrice,
            Transportation=constants.Transportation,
        };
    }

    public IEnumerable<ProductDefault> GetProducts()
    {
        var group = serviceProvider.GetRequiredService<ProductGroup>() with { };
        var list = group.ObjectToTList<Product>();
        var userId = Guid.Parse(SystemUserInfo.SystemUserId);
        foreach (var item in list)
            yield return new ProductDefault
            {
                CreatedUserId = userId,
                CreatedTime = DateTime.Now,
                Key = item.Key,
                Name = item.Value.Name,
                UnitPrice = item.Value.UnitPrice,
                Quantity = item.Value.Quantity
            };
    }

    public IEnumerable<ModuleDefault> GetModules()
    {
        var group = serviceProvider.GetRequiredService<ModuleGroup>() with { };
        var list = group.ObjectToTList<Module>();
        var userId = Guid.Parse(SystemUserInfo.SystemUserId);
        foreach (var item in list)
            yield return new()
            {
                CreatedUserId = userId,
                CreatedTime = DateTime.Now,
                Key = item.Key,
                Name = item.Value.Name,
                Dimensions = item.Value.Dimensions,
                TotalOrders = item.Value.TotalOrders,
                Type = item.Value.Type,
                Weight = item.Value.Weight
            };
    }
    public IEnumerable<RATDefault> GetRATs()
    {
        var group = serviceProvider.GetRequiredService<RATGroup>() with { };
        var list = group.ObjectToTList<RAT>();
        var userId = Guid.Parse(SystemUserInfo.SystemUserId);
        foreach (var item in list)
            yield return new()
            {
                CreatedUserId = userId,
                CreatedTime = DateTime.Now,
                Key = item.Key,
                Name = item.Value.Name,
                Weight = item.Value.Weight,
                DIP=item.Value.DIP,
                DKPS=item.Value.DKPS,
                LC=item.Value.LC,
                Quantity=item.Value.Quantity,
                RUB=item.Value.RUB
            };
    }
}
