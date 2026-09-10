using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Persistance.Repository;

public class Repository<T>(DbContext context) : IRepository<T> where T : class
{
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        => await _dbSet.FindAsync([id], cancellationToken);

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbSet.ToListAsync(cancellationToken);

    public async Task<PaginatedResult<T>> GetWhereAsync(
     Expression<Func<T, bool>> method,
     int pageNumber,
     int pageSize,
     bool tracking = true,
     CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _dbSet.Where(method);

        if (!tracking)
        {
            query = query.AsNoTracking();
        }

        return await query.ToPaginatedListAsync(pageNumber, pageSize, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(entity, cancellationToken);

    public void Update(T entity)
        => _dbSet.Update(entity);

    public void Delete(T entity)
        => _dbSet.Remove(entity);
}