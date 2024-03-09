using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
internal class CreateNewTokenByRefreshTokenCommandValidator : AbstractValidator<CreateNewTokenByRefreshTokenCommand>
{
    public CreateNewTokenByRefreshTokenCommandValidator()
    {
        RuleFor(p=> p.UserId).NotEmpty().WithMessage("User bilgisi boş olamaz");
        RuleFor(p=> p.UserId).NotNull().WithMessage("User bilgisi boş olamaz");
        RuleFor(p=> p.RefreshToken).NotNull().WithMessage("Refresh Token bilgisi boş olamaz");
        RuleFor(p=> p.UserId).NotEmpty().WithMessage("Refresh Token bilgisi boş olamaz");
    }
}
