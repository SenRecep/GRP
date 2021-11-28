﻿using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;
using GRP.Services.WaterTankCalculator.Entities.Enums;

using Microsoft.Extensions.DependencyInjection;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class CalculateManager : ICalculateService
{
    private IModuleService? moduleService;
    private IProductService? productService;
    private IRATService? ratService;
    private readonly IEdgeService edgeService;
    private readonly ITotalCostService totalCostService;
    private readonly IGenericDefaultService genericDefaultService;
    private readonly IServiceProvider serviceProvider;

    public CalculateManager(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.edgeService = serviceProvider.GetRequiredService<IEdgeService>();
        this.totalCostService = serviceProvider.GetRequiredService<ITotalCostService>();
        this.genericDefaultService = serviceProvider.GetRequiredService<IGenericDefaultService>();
    }
    private void LoadServices(PlinthType plinthType)
    {
        if (plinthType == PlinthType.Flat)
        {
            moduleService = serviceProvider.GetRequiredService<IFlatModuleService>();
            productService = serviceProvider.GetRequiredService<IFlatProductService>();
            ratService = serviceProvider.GetRequiredService<IFlatRATService>();
        }
        else
        {
            moduleService = serviceProvider.GetRequiredService<IBeamModuleService>();
            productService = serviceProvider.GetRequiredService<IBeamProductService>();
            ratService = serviceProvider.GetRequiredService<IBeamRATService>();
        }
    }
    public async Task<TotalCost> CalculateAsync(ConstantsModel constants, CalculateModel model)
    {
        LoadServices(model.PlinthType);
        TotalCost totalCost=new();
        var moduleGroup = await genericDefaultService.GetGroupAsync<ModuleGroup, ModuleDefault, Module>();
        var productGroup = await genericDefaultService.GetGroupAsync<ProductGroup, ProductDefault, Product>();
        var ratGroup = await genericDefaultService.GetGroupAsync<RATGroup, RATDefault, RAT>();
        CalculatedEdgeModel calculatedEdge = edgeService.EdgeCalculate(model);
        moduleService?.ModulesCalculate(moduleGroup, model, calculatedEdge.Capacity, constants);
        ratService?.RATSCalculate(ratGroup, model, constants);
        productService?.ProductsCalculate(productGroup, model, calculatedEdge, moduleGroup, constants, ratGroup);
        totalCostService.TotalCostCalculate(totalCost, moduleGroup, productGroup, ratGroup, constants);
        return totalCost;
    }
}