namespace GRP.Shared.DAL.Interfaces;

public interface IUnitOfWork : IAsyncDisposable
{
     Task<bool> Commit(bool state = true);
}
