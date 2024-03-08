using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
internal class GetAllCarQueryHandler(ICarService carService) : IRequestHandler<GetAllCarQuery,  PaginationResult<Car>>
{
    public async Task<PaginationResult<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Car> cars = await carService.GetAllAsync(request, cancellationToken);
        return cars;
    }
}
