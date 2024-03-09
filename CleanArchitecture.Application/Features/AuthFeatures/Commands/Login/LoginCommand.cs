using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
public record class LoginCommand(
    string UserNameOrEmail,
    string Password): IRequest<LoginCommandResponse>;
