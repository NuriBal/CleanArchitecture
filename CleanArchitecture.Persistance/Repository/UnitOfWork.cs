using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Persistance.Context;
using System.Collections.Concurrent;

namespace CleanArchitecture.Persistance.Repository;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly ConcurrentDictionary<Type, object> _repositories = new();

    public IRepository<T> Repository<T>() where T : class
    {
        return (IRepository<T>)_repositories.GetOrAdd(
            typeof(T),
            _ => new Repository<T>(context)
        );
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken);

    public ValueTask DisposeAsync()
        => context.DisposeAsync();
}
