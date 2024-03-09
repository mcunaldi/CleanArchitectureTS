using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Authorization;
using CleanArchitecture.Presentation.Abstractions;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

public sealed class CarsController(IMediator mediator) : ApiController
{
    //[TypeFilter(typeof(RoleAttribute), Arguments = new Object[] {"Create"})] daha kısası için RoleFilterAttribute class ı eklendi.
    [RoleFilter("Create")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateCarCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [RoleFilter("GetAll")]
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Car> response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}

