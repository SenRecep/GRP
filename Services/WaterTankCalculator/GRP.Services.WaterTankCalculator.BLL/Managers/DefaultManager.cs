using AutoMapper;

using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.BLL.Models.DTO;
using GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Contexts;

using Microsoft.EntityFrameworkCore;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class DefaultManager : IDefaultService
{
    private readonly WaterTankCalculatorDbContext context;
    private readonly IMapper mapper;

    public DefaultManager(WaterTankCalculatorDbContext context,IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
    public async Task<IEnumerable<ProductDto>> GetDefaultsProducts()
    {
        var defaults = await context.ProductDefaults.ToListAsync();
        return defaults.Select(x => mapper.Map<ProductDto>(x));
    }

    public async Task<IEnumerable<RATDto>> GetDefaultsRAT()
    {
        var defaults = await context.RATDefaults.ToListAsync();
        return defaults.Select(x => mapper.Map<RATDto>(x));
    }

    public async Task<ConstantsDto> GetDefaultsConstant()
    {
        var constants = await context.Constants.FirstOrDefaultAsync();
        return mapper.Map<ConstantsDto>(constants);
    }

    public async Task<IEnumerable<ModuleDto>> GetDefaultsModules()
    {
        var defaults = await context.ModuleDefaults.ToListAsync();
        return defaults.Select(x => mapper.Map<ModuleDto>(x));
    }

    //public async Task<IEnumerable<RatKV>> GetDefaultsRAT()
    //{
    //    var defaults = await context.RATDefaults.ToListAsync();
    //    return defaults.Select(x =>
    //     {
    //         var ret = new RatKV()
    //         {
    //             Key = x.Key,
    //             Name = x.Name
    //         };
    //         ret.KeyValueModels.Add(new() { Key = nameof(x.Weight), Value = x.Weight });
    //         ret.KeyValueModels.Add(new() { Key = nameof(x.DKPS), Value = x.DKPS });
    //         ret.KeyValueModels.Add(new() { Key = nameof(x.LC), Value = x.LC });
    //         ret.KeyValueModels.Add(new() { Key = nameof(x.DIP), Value = x.DIP });
    //         ret.KeyValueModels.Add(new() { Key = nameof(x.RUB), Value = x.RUB });
    //         return ret;
    //     });
    //}
}
