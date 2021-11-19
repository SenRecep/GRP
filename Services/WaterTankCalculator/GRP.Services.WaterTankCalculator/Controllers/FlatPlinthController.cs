

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class FlatPlinthController : ControllerBase
{
    private readonly IEdgeService edgeService;
    private readonly IModuleService moduleService;
    private readonly IServiceProvider serviceProvider;

    public FlatPlinthController(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.edgeService = serviceProvider.GetRequiredService<IEdgeService>();
        this.moduleService = serviceProvider.GetRequiredService<IModuleService>();
    }
    [HttpPost]
    public IActionResult Calculate(CalculateModel model)
    {
        var constants = new Constants() { GRPKgPrice = 2 };
        var moduleGroup = serviceProvider.GetRequiredService<ModuleGroup>();
        CalculatedEdgeModel calculatedEdge = edgeService.EdgeCalculate(model);
        moduleService.ModulesCalculate(moduleGroup, model, calculatedEdge.Capacity, constants);
        return Response<CalculatedEdgeModel>
            .Success(calculatedEdge, StatusCodes.Status200OK)
            .CreateResponseInstance();
    }
}
