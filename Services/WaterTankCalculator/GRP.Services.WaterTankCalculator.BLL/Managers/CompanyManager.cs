#nullable disable
using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Shared.Core.Response;

using Microsoft.AspNetCore.Http;

using System.Net.Http.Json;

using IdentityModel.Client;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class CompanyManager : ICompanyService
{
    private readonly HttpClient httpClient;
    private readonly IHttpContextAccessor httpContextAccessor;

    public CompanyManager(HttpClient httpClient,IHttpContextAccessor httpContextAccessor)
    {
        this.httpClient = httpClient;
        this.httpContextAccessor = httpContextAccessor;
    }
    public async Task<IEnumerable<Company>> GetCompanies()
    {
        var token = httpContextAccessor.HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
        httpClient.SetBearerToken(token);
        var res = await httpClient.GetFromJsonAsync<Response<IEnumerable<Company>>>($"/api/companies");
        return res.Data;
    }
    public async Task<Company> GetByIdAsync(Guid id)
    {
        var token = httpContextAccessor.HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ","");
        httpClient.SetBearerToken(token);
        var res= await httpClient.GetFromJsonAsync<Response<Company>>($"/api/companies/{id}");
        return res.Data;
    }
}
