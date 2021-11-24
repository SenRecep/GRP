using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;

using System.Net.Http.Json;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class ExcahangeManager:IExchangeService
{
    private readonly HttpClient httpClient;

    public ExcahangeManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<float> GetCurrentDollarValueAsync()
    {
        var res = await httpClient.GetAsync("");
        if (!res.IsSuccessStatusCode)
            return 13;
        var content = await res.Content.ReadFromJsonAsync<Exchange>();
        return Convert.ToSingle(content.USD.Alis);
    }
}
