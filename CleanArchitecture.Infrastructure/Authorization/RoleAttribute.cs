using CleanArchitecture.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CleanArchitecture.Infrastructure.Authorization;
public sealed class RoleAttribute(
    string role,
    IUserRoleRepository userRoleRepository) : Attribute, IAuthorizationFilter
{

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
        {
            context.Result = new UnauthorizedResult();
            return; //401 hatası döner.
        }

        var userHasRole = 
            userRoleRepository
            .GetWhere(p=> p.UserId == userIdClaim.Value)
            .Include(p=> p.Role)
            .Any(p=> p.Role.Name == role);

        if (!userHasRole)
        {
            context.Result = new UnauthorizedResult();
            return; //401 hatası döner.
        }
    }
}
