namespace GRP.Services.WaterTankCalculator.BLL.Interfaces;

public interface IExchangeService
{
    Task<float> GetCurrentDollarValueAsync();
}
