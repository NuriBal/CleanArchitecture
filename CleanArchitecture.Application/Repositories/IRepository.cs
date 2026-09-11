using CleanArchitecture.Application.Models;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PaginatedResult<T>> GetWhereAsync(Expression<Func<T, bool>> method, int pageNumber, int pageSize, bool tracking = true, CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
    IQueryable<T> GetQuery(bool tracking = true);
}