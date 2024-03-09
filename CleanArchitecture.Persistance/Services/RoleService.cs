using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistance.Services;
public sealed class RoleService(
    RoleManager<Role> roleManager) : IRoleService
{
    public async Task CreateAsync(CreateRoleCommand request)
    {
        Role role = new()
        {
            Name = request.Name,
        };

        await roleManager.CreateAsync(role);
    }
}
