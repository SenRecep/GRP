using GRP.Services.WaterTankCalculator.BLL.Models;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces;

public interface IRATService
{
    RATGroup RATSCalculate(RATGroup group,CalculateModel calculateModel, ConstantsModel constants);
}
