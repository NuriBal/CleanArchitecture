using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Services;

public sealed class CarService : ICarService
{
    private readonly IMapper _mapper;
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CarService(IMapper mapper, IUnitOfWork unitOfWork, ICarRepository carRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _carRepository = carRepository;
    }

    public async Task CreatAsync(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car car = _mapper.Map<Car>(request);
        //await _context.Set<Car>().AddAsync(car, cancellationToken);
        //await _context.SaveChangesAsync(cancellationToken);

        await _carRepository.AddAsync(car, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginatedResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        //PaginatedResult<Car> cars = await _carRepository.GetAllAsync(cancellationToken);
        //return cars;

        var searchFilter = string.IsNullOrWhiteSpace(request.Search);

        return await _carRepository.GetWhereAsync(
            method: car => searchFilter ||
                           car.Name.Trim().ToLower().Contains(request.Search!.Trim().ToLower()) ||
                           car.Model.Trim().ToLower().Contains(request.Search!.Trim().ToLower()),
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            tracking: false,
            cancellationToken: cancellationToken
        );
    }
}
