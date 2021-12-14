#nullable disable
using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;

using System.Net.Http.Json;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class ExcahangeManager : IExchangeService
{
    private readonly HttpClient httpClient;
    private readonly ICacheStore cacheStore;

    public ExcahangeManager(HttpClient httpClient, ICacheStore cacheStore)
    {
        this.httpClient = httpClient;
        this.cacheStore = cacheStore;
    }

    public async Task<float> GetCurrentDollarValueAsync()
    {
        var cacheKey = new ExchangeCacheKey();
        var exchange = cacheStore.Get(cacheKey);
        var defaultValue = 14f;
        if (exchange == null)
        {
            var res = await httpClient.GetAsync(string.Empty);
            if (!res.IsSuccessStatusCode)
                return defaultValue;
            exchange = await res.Content.ReadFromJsonAsync<Exchange>();
            if (exchange!=null)
                cacheStore.Add(exchange, cacheKey);
        }
        if (exchange ==null)
            return defaultValue;

        return exchange.Rates.TRY;
    }
}
