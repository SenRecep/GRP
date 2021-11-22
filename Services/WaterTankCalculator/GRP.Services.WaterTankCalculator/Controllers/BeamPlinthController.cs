
using GRP.Services.WaterTankCalculator.BLL.Models;

using Microsoft.Extensions.Options;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class BeamPlinthController : ControllerBase
{
    private readonly IEdgeService edgeService;
    private readonly IModuleService moduleService;
    private readonly IProductService productService;
    private readonly IRATService ratService;
    private readonly ITotalCostService totalCostService;
    private readonly IServiceProvider serviceProvider;

    public BeamPlinthController(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.edgeService = serviceProvider.GetRequiredService<IEdgeService>();
        this.moduleService = serviceProvider.GetRequiredService<IBeamModuleService>();
        this.productService = serviceProvider.GetRequiredService<IBeamProductService>();
        this.ratService = serviceProvider.GetRequiredService<IBeamRATService>();
        this.totalCostService = serviceProvider.GetRequiredService<ITotalCostService>();
    }

    [HttpPost]
    public IActionResult Calculate(CalculateModel model)
    {
        var constants = new Constants() { GRPKgPrice = 2, Dollar = 11.225197f, IntercityTransportation = 108 };
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
