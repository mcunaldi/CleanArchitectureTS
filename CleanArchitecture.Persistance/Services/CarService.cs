using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Services;
public sealed class CarService(
    IMapper mapper,
    ICarRepository carRepository,
    IUnitOfWork unitOfWork) : ICarService
{
    public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car car = mapper.Map<Car>(request);

        //await context.Set<Car>().AddAsync(car, cancellationToken);
        //await context.SaveChangesAsync(cancellationToken);

        await carRepository.AddAsync(car, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        IList<Car> cars = await carRepository.GetAll().ToListAsync(cancellationToken);
        return cars;
    }
}
