using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using GenericRepository;

namespace CleanArchitecture.Persistance.Services;
public sealed class UserRoleService(
    IUserRoleRepository userRoleRepository,
    IUnitOfWork unitOfWork) : IUserRoleService
{
    public async Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        UserRole userRole = new()
        {
            RoleId = request.RoleId,
            UserId = request.UserId
        };
        
        await userRoleRepository.AddAsync(userRole);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
