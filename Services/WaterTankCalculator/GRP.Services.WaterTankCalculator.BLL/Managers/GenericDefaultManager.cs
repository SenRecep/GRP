using AutoMapper;

using GRP.Core.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.Entities.Interfaces.Defaults;
using GRP.Shared.DAL.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class GenericDefaultManager : IGenericDefaultService
{
    private readonly IServiceProvider serviceProvider;
    private readonly IMapper mapper;

    public GenericDefaultManager(IServiceProvider serviceProvider, IMapper mapper)
    {
        this.serviceProvider = serviceProvider;
        this.mapper = mapper;
    }
    public async Task<T> GetGroupAsync<T, J, M>()
        where J : class, IEntityBase, IDefaultEntitiy, new()
        where M : class, new()
        where T : class, new()
    {
        var group = new T();
        var repository = serviceProvider.GetRequiredService<IGenericQueryRepository<J>>();
        var data = await repository.GetAllAsync();
        group.GetType().GetProperties().ToList().ForEach(p =>
        {
            if (p.PropertyType != typeof(M)) return;
            var key = p.Name;
            var found = data.Where(x => x.Key == key).FirstOrDefault();
            var map = mapper.Map<M>(found);
            p.SetValue(group, map);
        });
        return group;
    }
}
