using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.BLL.Models.DTO;
using GRP.Services.WaterTankCalculator.Entities.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;
using GRP.Shared.BLL.Interfaces;

namespace GRP.Services.WaterTankCalculator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DefaultsController : ControllerBase
{
    private readonly IDefaultService defaultService;
    private readonly IGenericCommandService<ProductDefault> productDefaultService;
    private readonly IGenericCommandService<ModuleDefault> moduleDefaultService;
    private readonly IGenericCommandService<RATDefault> ratDefaultService;
    private readonly IGenericCommandService<Constants> constantsService;

    public DefaultsController(
        IDefaultService defaultService,
        IGenericCommandService<ProductDefault> productDefaultService,
        IGenericCommandService<ModuleDefault> moduleDefaultService,
        IGenericCommandService<RATDefault> ratDefaultService,
        IGenericCommandService<Constants> constantsService
        )
    {
        this.defaultService = defaultService;
        this.productDefaultService = productDefaultService;
        this.moduleDefaultService = moduleDefaultService;
        this.ratDefaultService = ratDefaultService;
        this.constantsService = constantsService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await defaultService.GetDefaultsProducts();
        var rats = await defaultService.GetDefaultsRAT();
        var constants = await defaultService.GetDefaultsConstant();
        var modules = await defaultService.GetDefaultsModules();
        return Response<dynamic>.Success(new
        {
            products,
            rats,
            modules,
            constants
        }).CreateResponseInstance();
    }

    [HttpPut("productUpdate")]
    public async Task<IActionResult> Put(ProductDto dto)
    {
        await productDefaultService.UpdateAsync(dto);
        await productDefaultService.Commit();
        return Response<NoContent>.Success(StatusCodes.Status204NoContent).CreateResponseInstance();
    }

    [HttpPut("moduleUpdate")]
    public async Task<IActionResult> Put(ModuleDto dto)
    {
        await moduleDefaultService.UpdateAsync(dto);
        await moduleDefaultService.Commit();
        return Response<NoContent>.Success(StatusCodes.Status204NoContent).CreateResponseInstance();
    }

    [HttpPut("ratUpdate")]
    public async Task<IActionResult> Put(RATDto dto)
    {
        await ratDefaultService.UpdateAsync(dto);
        await ratDefaultService.Commit();
        return Response<NoContent>.Success(StatusCodes.Status204NoContent).CreateResponseInstance();
    }

    [HttpPut("constantUpdate")]
    public async Task<IActionResult> Put(ConstantsDto dto)
    {
        await constantsService.UpdateAsync(dto);
        await constantsService.Commit();
        return Response<NoContent>.Success(StatusCodes.Status204NoContent).CreateResponseInstance();
    }


}
