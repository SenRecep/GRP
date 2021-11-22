using GRP.Services.WaterTankCalculator.BLL.Models;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces;

public interface IEdgeService
{
    CalculatedEdgeModel EdgeCalculate(CalculateModel calculateModel);
}
