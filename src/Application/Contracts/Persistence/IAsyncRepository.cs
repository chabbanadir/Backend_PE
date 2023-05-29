using System.Linq.Expressions;

namespace Backend.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(string[]? includes = null, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> predicate, string[]? includes = null, CancellationToken cancellationToken = default);
    Task<T> GetByIdAsync(Guid id, string[]? includes = null, CancellationToken cancellationToken = default);
    Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    Task<T> Create(T entity, CancellationToken cancellationToken = default);
    Task<bool> Update(T entity, CancellationToken cancellationToken = default);
    Task<bool>  Delete(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<object>> GetAllDrawingData();
}