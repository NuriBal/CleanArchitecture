using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

namespace CleanArchitecture.Application.Services;

public interface IRoleService
{
    Task CreatAsync(CreateRoleCommand request);
}
