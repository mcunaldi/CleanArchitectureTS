using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
internal class GetAllCarQueryHandler(ICarService carService) : IRequestHandler<GetAllCarQuery, IList<Car>>
{
    public async Task<IList<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        IList<Car> cars = await carService.GetAllAsync(request, cancellationToken);
        return cars;
    }
}
