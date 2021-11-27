using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.Entities.Concrete;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces;

public interface ITransportationService
{
    Transportation Calculate(Constants constants,MultipleCalculateModel model);
}
