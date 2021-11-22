using GRP.Core.Interfaces;
using GRP.Shared.DAL.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace GRP.Shared.DAL.Concrete.EntityFrameworkCore.Repositories;

public class EfGenericQueryRepository<T> : IGenericQueryRepository<T>
 where T : class, IEntityBase, new()
{
    private readonly DbContext dbContext;
    private readonly DbSet<T> table;


    public EfGenericQueryRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
        table = dbContext.Set<T>();

    }


    #region GetAll
    public  Task<IEnumerable<T>> GetAllAsync() =>  Task.FromResult(table.Where(x => !x.IsDeleted).AsEnumerable());

    public  Task<IEnumerable<T>> GetAllWithDeletedAsync() =>  Task.FromResult(table.AsEnumerable());
    #endregion


    #region Get
    public  ValueTask<T?> GetByIdAsync(Guid id) =>  table.FindAsync(id);
    #endregion

    #region Dispose

    public  ValueTask DisposeAsync() =>  dbContext.DisposeAsync();
    #endregion
}
