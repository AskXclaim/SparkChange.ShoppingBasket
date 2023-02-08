namespace ShoppingBasket.Application.Contracts.Persistence.Common;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task AddAsync(T entity);
    Task<T?> GetAsync(int id);
    Task<List<T>> GetAllAsync();
}