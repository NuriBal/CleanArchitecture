using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar
{
    public sealed class GetAllCarQueryHandle : IRequestHandler<GetAllCarQuery, IList<Car>>
    {
        private readonly ICarService _carService;

        public GetAllCarQueryHandle(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<IList<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            IList<Car> cars = await _carService.GetAllAsync(request, cancellationToken);
            return cars;
        }
    }
}
