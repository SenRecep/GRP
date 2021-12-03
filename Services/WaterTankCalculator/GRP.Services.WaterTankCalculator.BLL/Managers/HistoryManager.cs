#nullable disable
using AutoMapper;

using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Contexts;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;
using GRP.Services.WaterTankCalculator.Entities.Concrete.History;
using GRP.Shared.Core.ExtensionMethods;
using GRP.Shared.Core.Services.Interfaces;
using GRP.Shared.DAL.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class HistoryManager : IHistoryService
{
    private readonly WaterTankCalculatorDbContext context;
    private readonly IMapper mapper;
    private readonly ISharedIdentityService sharedIdentityService;
    public HistoryManager(
        WaterTankCalculatorDbContext context,
        IMapper mapper,
        ISharedIdentityService sharedIdentityService)
    {
        this.context = context;
        this.mapper = mapper;
        this.sharedIdentityService = sharedIdentityService;
    }
    public async Task<Guid> SaveAsync(MultipleCalculateModel model, ConstantsModel constantsModel, ICollection<CalculateResponse> calculateResponses)
    {
        var userId = Guid.Parse(sharedIdentityService.GetUserId);
        var history = new CalculationHistory() { CreatedUserId = userId, CompnyId = model.CompnyId, CurrencyType = model.CurrencyType };
        await context.AddAsync(history);
        await context.SaveChangesAsync();

        var constantsHistory = mapper.Map<ConstantsHistory>(constantsModel);
        constantsHistory.CreatedUserId = userId;
        constantsHistory.CalculationHistory = history;
        constantsHistory.CalculationHistoryId = history.Id;
        await context.AddAsync(constantsHistory);
        await context.SaveChangesAsync();

        var productDefaults = await context.ProductDefaults.ToListAsync();
        var ratDefaults = await context.RATDefaults.ToListAsync();
        var moduleDefaults = await context.ModuleDefaults.ToListAsync();
        foreach (var calculate in calculateResponses)
        {
            var calculateModelHistory = mapper.Map<CalculateModelHistory>(calculate.CalculateModel);
            calculateModelHistory.CalculationHistoryId = history.Id;
            calculateModelHistory.CreatedUserId = userId;
            await context.AddAsync(calculateModelHistory);
            await context.SaveChangesAsync();

            var totalCostHistory = mapper.Map<TotalCostHistory>(calculate.TotalCost);
            totalCostHistory.CalculateModelHistory = calculateModelHistory;
            totalCostHistory.CreatedUserId = userId;
            totalCostHistory.FullTotal = calculate.CalculateModel.Quantity * totalCostHistory.Total;
            history.Total += totalCostHistory.FullTotal;
            await context.AddAsync(totalCostHistory);
            await context.SaveChangesAsync();


            var edgeModelHistory = calculate.CalculatedEdgeModel.Map();
            edgeModelHistory.CalculateModelHistory = calculateModelHistory;
            edgeModelHistory.CreatedUserId = userId;

            await context.AddAsync(edgeModelHistory);
            await context.SaveChangesAsync();

            calculateModelHistory.EdgeModelHistoryId = edgeModelHistory.Id;
            calculateModelHistory.TotalCostHistoryId = totalCostHistory.Id;
            await context.SaveChangesAsync();



            var products = calculate.ProductGroup.ObjectToTList<Product>();
            foreach (var product in products)
            {
                var defaultRecord = productDefaults.Where(x => x.Key == product.Key).FirstOrDefault();
                var productHistory = mapper.Map<ProductHistory>(product.Value);
                productHistory.ProductDefault = defaultRecord;
                productHistory.CalculateModelHistory = calculateModelHistory;
                productHistory.CreatedUserId = userId;

                await context.AddAsync(productHistory);
            }
            var modules = calculate.ModuleGroup.ObjectToTList<Module>();
            foreach (var module in modules)
            {
                var defaultRecord = moduleDefaults.Where(x => x.Key == module.Key).FirstOrDefault();
                var moduleHistory = mapper.Map<ModuleHistory>(module.Value);
                moduleHistory.ModuleDefault = defaultRecord;
                moduleHistory.CalculateModelHistory = calculateModelHistory;
                moduleHistory.CreatedUserId = userId;

                await context.AddAsync(moduleHistory);
            }
            var rats = calculate.RATGroup.ObjectToTList<RAT>();
            foreach (var rat in rats)
            {
                var defaultRecord = ratDefaults.Where(x => x.Key == rat.Key).FirstOrDefault();
                var ratHistory = mapper.Map<RATHistory>(rat.Value);
                ratHistory.RATDefault = defaultRecord;
                ratHistory.CalculateModelHistory = calculateModelHistory;
                ratHistory.CreatedUserId = userId;
                await context.AddAsync(ratHistory);
            }
            context.SaveChanges();
        }
        history.KDV = history.Total * 0.18f;
        history.FullTotal = history.KDV + history.Total;
        context.SaveChanges();
        return history.Id;
    }
}
