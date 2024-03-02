using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistance.Services;
public sealed class CarService(AppDbContext context,
    IMapper mapper) : ICarService
{
    public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car car = mapper.Map<Car>(request);

        await context.Set<Car>().AddAsync(car, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
