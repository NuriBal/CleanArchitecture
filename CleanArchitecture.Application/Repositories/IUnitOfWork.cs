namespace CleanArchitecture.Application.Repositories;

public interface IUnitOfWork : IAsyncDisposable
{
    IRepository<T> Repository<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
