using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(p=> p.Name).NotEmpty().WithMessage("Role adı boş olamaz!");
        RuleFor(p=> p.Name).NotNull().WithMessage("Role adı boş olamaz!");
    }
}
