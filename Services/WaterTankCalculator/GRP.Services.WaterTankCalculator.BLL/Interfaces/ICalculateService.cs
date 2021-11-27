using GRP.Services.WaterTankCalculator.BLL.Models;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces;

public interface ICalculateService
{
    Task<TotalCost> CalculateAsync(ConstantsModel constantsModel, CalculateModel model,CancellationToken cancellationToken);
}
