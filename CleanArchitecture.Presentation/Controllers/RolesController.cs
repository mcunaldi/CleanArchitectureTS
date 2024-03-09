using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;
public sealed class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
