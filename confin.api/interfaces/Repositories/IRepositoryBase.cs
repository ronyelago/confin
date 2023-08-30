namespace confin.api.interfaces.repositories;

public interface IRepositoryBase<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<string> AddAsync(T entity);
}