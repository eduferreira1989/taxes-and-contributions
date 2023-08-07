using System.Linq.Expressions;
using TAC.Common.Entities;

namespace TAC.Common.Interfaces;

public interface IRepository<T> where T : IEntity
{
    Task<IReadOnlyCollection<T>> GetAllAsync();

    Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);

    Task<T> GetAsync(Guid id);

    Task<T> GetAsync(Expression<Func<T, bool>> filter);

    Task CreateAsync(T entity);

    Task UpdateAsync(T entity);

    Task RemoveAsync(Guid id);
}