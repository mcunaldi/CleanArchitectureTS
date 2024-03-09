using CleanArchitecture.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
public sealed class LoginCommandHandler(
    IAuthService authService) : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await authService.LoginAsync(request, cancellationToken);

        return response;
    }
}
