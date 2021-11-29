using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.Entities.Enums;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces;

public interface ICalculateService
{
    Task<CalculateResponse> CalculateAsync(ConstantsModel constantsModel, CalculateModel model, PaymentType paymentType);
}
