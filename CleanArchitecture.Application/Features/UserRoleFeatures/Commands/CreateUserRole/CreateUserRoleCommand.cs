﻿using CleanArchitecture.Domain.DTOs;
using MediatR;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
public sealed record CreateUserRoleCommand(
    string RoleId,
    string UserId) : IRequest<MessageResponse>;
