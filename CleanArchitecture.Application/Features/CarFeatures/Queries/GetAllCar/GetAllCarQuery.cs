using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;

public sealed record GetAllCarQuery : PageRequest, IRequest<PaginatedResult<Car>>
{
    public string Search { get; init; }

    public GetAllCarQuery() { }

    public GetAllCarQuery(int pageNumber, int pageSize, string search)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Search = search;
    }
}
