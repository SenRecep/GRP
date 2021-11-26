using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;
using GRP.Services.WaterTankCalculator.Entities.Enums;

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
    private readonly IGenericDefaultService genericDefaultService;

    public PlinthController(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.edgeService = serviceProvider.GetRequiredService<IEdgeService>();
        this.totalCostService = serviceProvider.GetRequiredService<ITotalCostService>();
        this.exchangeService = serviceProvider.GetRequiredService<IExchangeService>();
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

    [HttpPost]
    public async Task<IActionResult> Calculate(CalculateModel model)
    {
        LoadServices(model.PlinthType);
        var dollar = await exchangeService.GetCurrentDollarValueAsync();
        var constants = new Constants() { GRPKgPrice = 2.25f, Dollar = dollar, IntercityTransportation = 108 };
        var moduleGroup = await genericDefaultService.GetGroupAsync<ModuleGroup,ModuleDefault,Module>();
        var productGroup = await genericDefaultService.GetGroupAsync<ProductGroup,ProductDefault,Product>();
        var ratGroup = await genericDefaultService.GetGroupAsync<RATGroup,RATDefault,RAT>();
        CalculatedEdgeModel calculatedEdge = edgeService.EdgeCalculate(model);
        moduleService?.ModulesCalculate(moduleGroup, model, calculatedEdge.Capacity, constants);
        ratService?.RATSCalculate(ratGroup, model, constants);
        productService?.ProductsCalculate(productGroup, model, calculatedEdge, moduleGroup, constants, ratGroup);
        var totalCost = totalCostService.TotalCostCalculate(new(), moduleGroup, productGroup, ratGroup, constants);
        return Response<dynamic>
            .Success(new
            {
                constants,
                moduleGroup = moduleGroup.ObjectToList<Module>(),
                productGroup = productGroup.ObjectToList<Product>(),
                ratGroup = ratGroup.ObjectToList<RAT>(),
                totalCost
            }, StatusCodes.Status200OK)
            .CreateResponseInstance();
    }
}
