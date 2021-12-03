namespace GRP.Shared.Core.Interfaces
{
    public interface ICustomMapper
    {
        public T Map<T, D>(D dto, T entity);
    }
}
