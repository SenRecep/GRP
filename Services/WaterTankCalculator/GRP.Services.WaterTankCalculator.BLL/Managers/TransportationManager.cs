using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.Entities.Concrete;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class TransportationManager : ITransportationService
{
    public Transportation Calculate(Constants
        constants, MultipleCalculateModel model)
    {
        var count = model.CalculateModels.Sum(x => x.Quantity);
        var value= constants.Transportation* count switch
        {
            <= 3 => 1.35f,
            4 or 5 or 6=>1.15f,
            _=>1
        };
        return new() { Value = value, };
    }
}
