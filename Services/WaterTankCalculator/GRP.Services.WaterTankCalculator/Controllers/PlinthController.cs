#nullable disable
using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.Entities.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Enums;
using GRP.Shared.DAL.Interfaces;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class PlinthController : ControllerBase
{
    private readonly ICalculateService calculateService;
    private readonly ITransportationService transportationService;
    private readonly IGenericQueryRepository<Constants> genericQueryRepository;
    private readonly IExchangeService exchangeService;
    private readonly IHistoryService historyService;

    public PlinthController(
        ICalculateService calculateService,
        ITransportationService transportationService,
        IGenericQueryRepository<Constants> genericQueryRepository,
        IExchangeService exchangeService,
        IHistoryService historyService)
    {
        this.calculateService = calculateService;
        this.transportationService = transportationService;
        this.genericQueryRepository = genericQueryRepository;
        this.exchangeService = exchangeService;
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
        ICollection<CalculateResponse> calculateResponses = new List<CalculateResponse>();
        foreach (var item in model.CalculateModels)
        {
            var response = await calculateService.CalculateAsync(constantsModel, item);
            calculateResponses.Add(response);
        }
        await historyService.SaveAsync(model, calculateResponses);
        return Response<ICollection<CalculateResponse>>
            .Success(calculateResponses, StatusCodes.Status200OK)
            .CreateResponseInstance();
    }
}
