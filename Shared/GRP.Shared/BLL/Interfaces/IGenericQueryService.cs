using GRP.Core.Interfaces;

namespace GRP.Shared.BLL.Interfaces;

public interface IGenericQueryService<T>
       where T : class, IEntityBase, new()
{
    public Task<IEnumerable<D>> GetAllAsync<D>() where D : IDTO;
    public Task<IEnumerable<D>> GetAllWithDeletedAsync<D>() where D : IDTO;
    public Task<D> GetByIdAsync<D>(Guid id) where D : IDTO;

}
