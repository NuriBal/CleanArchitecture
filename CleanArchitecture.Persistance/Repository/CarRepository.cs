using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Context;

namespace CleanArchitecture.Persistance.Repository;

public sealed class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context) {}
}
