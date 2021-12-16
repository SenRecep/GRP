#nullable disable
using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Contexts;
using GRP.Services.WaterTankCalculator.Entities.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Enums;
using GRP.Shared.DAL.Interfaces;

using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PlinthController : ControllerBase
{
    private readonly WaterTankCalculatorDbContext context;
    private readonly ICompanyService companyService;
    private readonly ICalculateService calculateService;
    private readonly ITransportationService transportationService;
    private readonly IGenericQueryRepository<Constants> genericQueryRepository;
    private readonly IExchangeService exchangeService;
    private readonly IExportService exportService;
    private readonly IHistoryService historyService;

    public PlinthController(
        ICalculateService calculateService,
        WaterTankCalculatorDbContext context,
        ICompanyService companyService,
        ITransportationService transportationService,
        IGenericQueryRepository<Constants> genericQueryRepository,
        IExchangeService exchangeService,
        IExportService exportService,
        IHistoryService historyService)
    {
        this.context = context;
        this.companyService = companyService;
        this.calculateService = calculateService;
        this.transportationService = transportationService;
        this.genericQueryRepository = genericQueryRepository;
        this.exchangeService = exchangeService;
        this.exportService = exportService;
        this.historyService = historyService;
    }

 
    [HttpPost]
    public async Task<IActionResult> Calculate(MultipleCalculateModel model)
    {
        var constants = (await genericQueryRepository.GetAllAsync()).FirstOrDefault();
        var transportation = transportationService.Calculate(constants, model);
        var Dollar = await exchangeService.GetCurrentDollarValueAsync();
        var constantsModel = new ConstantsModel()
        {
            GRPKgPrice = constants.GRPKgPrice,
            Dollar = Dollar,
            Transportation = transportation.Value
        };
        List<CalculateResponse> calculateResponses = new();
        foreach (var item in model.CalculateModels)
        {
            var response = await calculateService.CalculateAsync(constantsModel, item);
            calculateResponses.Add(response);
        }
        var history = await historyService.SaveAsync(model, constantsModel, calculateResponses);
        await exportService.CreateAsync(history);
        return Response<Guid>
            .Success(history, StatusCodes.Status200OK)
            .CreateResponseInstance();
    }
}
