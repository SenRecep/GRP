using GRP.Services.WaterTankCalculator.BLL.Interfaces;

namespace GRP.Services.WaterTankCalculator.BLL.Models;

internal class ExchangeCacheKey : ICacheKey<Exchange>
{
    public string CacheKey => "ExchangeDollar";
}
