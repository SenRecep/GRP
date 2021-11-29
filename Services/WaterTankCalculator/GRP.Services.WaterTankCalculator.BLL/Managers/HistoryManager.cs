using AutoMapper;

using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;
using GRP.Services.WaterTankCalculator.Entities.Concrete.History;
using GRP.Shared.Core.ExtensionMethods;
using GRP.Shared.DAL.Interfaces;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class HistoryManager : IHistoryService
{
    private readonly IMapper mapper;
    private readonly IGenericCommandRepository<CalculationHistory> calculationHistoryRepository;
    private readonly IGenericQueryRepository<ProductDefault> productDefaultGenericRepository;

    public HistoryManager(
        IMapper mapper,
        IGenericCommandRepository<CalculationHistory> CalculationHistoryRepository,
        IGenericQueryRepository<ProductDefault> productDefaultGenericRepository)
    {
        this.mapper = mapper;
        calculationHistoryRepository = CalculationHistoryRepository;
        this.productDefaultGenericRepository = productDefaultGenericRepository;
    }
    public async Task SaveAsync(MultipleCalculateModel model, ICollection<CalculateResponse> calculateResponses)
    {
        var history = new CalculationHistory();
        await calculationHistoryRepository.AddAsync(history);
        await calculationHistoryRepository.Commit();
        await calculationHistoryRepository.DisposeAsync();
        //var productDefaults = await productDefaultGenericRepository.GetAllAsync();
        //foreach (var calculate in calculateResponses)
        //{
        //    var calculateModelHistory = mapper.Map<CalculateModelHistory>(calculate.CalculateModel);
        //    var constantsHistory = mapper.Map<ConstantsHistory>(calculate.ConstantsModel);
        //    var products = calculate.ProductGroup.ObjectToTList<Product>();
        //    foreach (var product in products)
        //    {
        //        var defaultRecord = productDefaults.Where(x => x.Key == product.Key).FirstOrDefault();
        //        var productHistory = mapper.Map<ProductHistory>(product.Value);
        //        productHistory.ProductDefault = defaultRecord;
        //    }
        //}
    }
}
