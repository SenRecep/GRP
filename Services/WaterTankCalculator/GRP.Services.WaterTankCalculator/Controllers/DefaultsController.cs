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
    private readonly IExchangeService exchangeService;

    public DefaultsController(
        IDefaultService defaultService,
        IGenericCommandService<ProductDefault> productDefaultService,
        IGenericCommandService<ModuleDefault> moduleDefaultService,
        IGenericCommandService<RATDefault> ratDefaultService,
        IGenericCommandService<Constants> constantsService,
        IExchangeService exchangeService
        )
    {
        this.defaultService = defaultService;
        this.productDefaultService = productDefaultService;
        this.moduleDefaultService = moduleDefaultService;
        this.ratDefaultService = ratDefaultService;
        this.constantsService = constantsService;
        this.exchangeService = exchangeService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var dollar= await exchangeService.GetCurrentDollarValueAsync();
        var products = await defaultService.GetDefaultsProducts();
        var rats = await defaultService.GetDefaultsRAT();
        var constants = await defaultService.GetDefaultsConstant();
        products = products.Select(x=> x with
        {
            UnitPrice = x.UnitPrice / dollar,
        });

        rats = rats.Select(x => x with
        {
            DIP = x.DIP / dollar,
            DKPS = x.DKPS / dollar,
            LC = x.DIP / dollar,
            RUB = x.DIP / dollar
        });

        return Response<dynamic>.Success(new
        {
            products,
            rats,
            constants,
            dollar
        }).CreateResponseInstance();
    }

    [HttpPut("productUpdate")]
    public async Task<IActionResult> Put(ProductDto dto)
    {
        var dollar = await exchangeService.GetCurrentDollarValueAsync();
        dto.UnitPrice *= dollar;
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
        var dollar = await exchangeService.GetCurrentDollarValueAsync();
        dto = dto with
        {
            DIP = dto.DIP * dollar,
            DKPS = dto.DKPS * dollar,
            LC = dto.DIP * dollar,
            RUB = dto.DIP * dollar
        };
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
