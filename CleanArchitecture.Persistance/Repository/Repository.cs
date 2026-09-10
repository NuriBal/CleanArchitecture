using CleanArchitecture.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Repository;

public class Repository<T>(DbContext context) : IRepository<T> where T : class
{
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        => await _dbSet.FindAsync([id], cancellationToken);

    public async Task<IList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbSet.ToListAsync(cancellationToken);

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(entity, cancellationToken);

    public void Update(T entity)
        => _dbSet.Update(entity);

    public void Delete(T entity)
        => _dbSet.Remove(entity);
}