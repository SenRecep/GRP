using AutoMapper;

using GRP.Shared.BLL.Interfaces;
using GRP.Shared.DAL.Interfaces;
using GRP.Core.Interfaces;

namespace GRP.Shared.BLL.Managers;

public class GenericCommandManager<T> : IGenericCommandService<T>
 where T : class, IEntityBase, new()
{
    private readonly IGenericCommandRepository<T> genericRepository;
    private readonly IGenericQueryRepository<T> genericQueryRepository;
    private readonly IMapper mapper;
    private readonly ICustomMapper customMapper;

    public GenericCommandManager(
        IGenericCommandRepository<T> genericRepository,
        IGenericQueryRepository<T> genericQueryRepository,
        IMapper mapper,
        ICustomMapper customMapper)
    {
        this.genericRepository = genericRepository;
        this.genericQueryRepository = genericQueryRepository;
        this.mapper = mapper;
        this.customMapper = customMapper;
    }

    public async Task<T> AddAsync<D>(D dto) where D : IDTO
    {
        T entity = mapper.Map<T>(dto);
        await genericRepository.AddAsync(entity);
        return entity;
    }

    public async Task RemoveAsync<D>(D dto, bool hardDelete = false) where D : IDTO
    {
        T dummyEntity = mapper.Map<T>(dto);
        T? orjinal = await genericQueryRepository.GetByIdAsync(dummyEntity.Id);
        if (orjinal is null) throw new NullReferenceException(nameof(orjinal));
        orjinal = customMapper.Map(dto, orjinal);
        await genericRepository.RemoveAsync(orjinal, hardDelete);
    }

    public async Task UpdateAsync<D>(D dto) where D : IDTO
    {
        T dummyEntity = mapper.Map<T>(dto);
        T? orjinal = await genericQueryRepository.GetByIdAsync(dummyEntity.Id);
        if (orjinal is null) throw new NullReferenceException(nameof(orjinal));
        orjinal = customMapper.Map(dto, orjinal);
        await genericRepository.UpdateAsync(orjinal);
    }

    public  Task<bool> Commit(bool state = true) =>  genericRepository.Commit(state);
}
