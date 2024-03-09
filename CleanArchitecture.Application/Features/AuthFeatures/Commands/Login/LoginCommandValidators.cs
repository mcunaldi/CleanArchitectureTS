using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
public sealed class LoginCommandValidators : AbstractValidator<LoginCommand>
{
    public LoginCommandValidators()
    {
        RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Giriş bilgisi boş olamaz!");
        RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Giriş bilgisi boş olamaz!");
        RuleFor(p => p.UserNameOrEmail).MinimumLength(3).WithMessage("Giriş bilgisien az 3 karakter olmalıdır!");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre alanı boş olamaz!");
        RuleFor(p => p.Password).NotNull().WithMessage("Şifre alanı boş olamaz!");
    }
}
