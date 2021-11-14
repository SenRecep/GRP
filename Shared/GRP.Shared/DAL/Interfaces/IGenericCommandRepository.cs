using GRP.Core.Interfaces;

namespace GRP.Shared.DAL.Interfaces;

public interface IGenericCommandRepository<T> : IUnitOfWork
       where T : class, IEntityBase, new()
{
     Task<T> AddAsync(T entity);
     Task AddRangeAsync(IEnumerable<T> entities);
     Task UpdateAsync(T entity);
     Task RemoveAsync(T entity, bool hardDelete = false);
     Task<int> SaveChangesAsync();
}
