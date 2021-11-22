using AutoMapper;

using GRP.Shared.BLL.Interfaces;
using GRP.Core.Interfaces;
using GRP.Shared.DAL.Interfaces;


namespace GRP.Shared.BLL.Managers;

public class GenericQueryManager<T> : IGenericQueryService<T>
where T : class, IEntityBase, new()
{
    private readonly IGenericQueryRepository<T> genericRepository;
    private readonly IMapper mapper;

    public GenericQueryManager(IGenericQueryRepository<T> genericRepository, IMapper mapper)
    {
        this.genericRepository = genericRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<D>> GetAllAsync<D>() where D : IDTO
    {
        IEnumerable<T> entities = await genericRepository.GetAllAsync();
        IEnumerable<D> result = mapper.Map<IEnumerable<D>>(entities);
        return result;
    }

    public async Task<IEnumerable<D>> GetAllWithDeletedAsync<D>() where D : IDTO
    {
        IEnumerable<T> entities = await genericRepository.GetAllWithDeletedAsync();
        IEnumerable<D> result = mapper.Map<IEnumerable<D>>(entities);
        return result;
    }

    public async Task<D> GetByIdAsync<D>(Guid id) where D : IDTO
    {
        T? entity = await genericRepository.GetByIdAsync(id);
        D result = mapper.Map<D>(entity);
        return result;
    }
}
