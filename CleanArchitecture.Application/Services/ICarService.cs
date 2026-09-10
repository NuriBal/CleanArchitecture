using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services;

public interface ICarService
{
    Task CreatAsync(CreateCarCommand request, CancellationToken cancellationToken);
    Task<PaginatedResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken);
}
