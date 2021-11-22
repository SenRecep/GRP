using GRP.Services.WaterTankCalculator.BLL.Enums;
using GRP.Services.WaterTankCalculator.BLL.Models;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class PlinthController : ControllerBase
{
    private readonly IEdgeService edgeService;
    private readonly IExchangeService exchangeService;
    private IModuleService? moduleService;
    private IProductService? productService;
    private IRATService? ratService;
    private readonly ITotalCostService totalCostService;
    private readonly IServiceProvider serviceProvider;

    public PlinthController(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.edgeService = serviceProvider.GetRequiredService<IEdgeService>();
        this.totalCostService = serviceProvider.GetRequiredService<ITotalCostService>();
        this.exchangeService = serviceProvider.GetRequiredService<IExchangeService>();
    }

    [HttpPost]
    public async Task<IActionResult> Calculate(CalculateModel model)
    {
        if (model.PlinthType==PlinthType.Flat)
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

        var dollar = await exchangeService.GetCurrentDollarValueAsync();
        var constants = new Constants() { GRPKgPrice = 2, Dollar = dollar, IntercityTransportation = 108 };
        var moduleGroup = serviceProvider.GetRequiredService<ModuleGroup>() with { };
        var productGroup = serviceProvider.GetRequiredService<ProductGroup>() with { };
        var ratGroup = serviceProvider.GetRequiredService<RATGroup>() with { };
        CalculatedEdgeModel calculatedEdge = edgeService.EdgeCalculate(model);
        moduleService.ModulesCalculate(moduleGroup, model, calculatedEdge.Capacity, constants);
        ratService.RATSCalculate(ratGroup, model, constants);
        productService.ProductsCalculate(productGroup, model, calculatedEdge, moduleGroup, constants, ratGroup);
        var totalCost = totalCostService.TotalCostCalculate(new(), moduleGroup, productGroup, ratGroup, constants);
        return Response<dynamic>
            .Success(new
            {
                constants,
                moduleGroup,
                productGroup,
                ratGroup,
                totalCost
            }, StatusCodes.Status200OK)
            .CreateResponseInstance();
    }
}
