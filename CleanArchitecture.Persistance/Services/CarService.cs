using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;

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

    public async Task<IList<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        IList<Car> cars = await _carRepository.GetAllAsync(cancellationToken);
        return cars;
    }
}
