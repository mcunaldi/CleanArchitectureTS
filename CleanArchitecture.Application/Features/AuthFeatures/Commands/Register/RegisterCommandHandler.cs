using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
public sealed class RegisterCommandHandler(
    IAuthService authService) : IRequestHandler<RegisterCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await authService.RegisterAsync(request);
        return new("Kullanıcı kaydı başarıyla tamamlandı!");
    }
}
