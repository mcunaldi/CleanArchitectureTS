using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;
public sealed class AuthController(IMediator mediator) : ApiController
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTokenByRefreshToken(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
