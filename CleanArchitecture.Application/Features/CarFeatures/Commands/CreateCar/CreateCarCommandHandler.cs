using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
public sealed class CreateCarCommandHandler(ICarService carService) : IRequestHandler<CreateCarCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        await carService.CreateAsync(request, cancellationToken);

        return new("Araç başarıyla kaydedildi!");
    }
}
