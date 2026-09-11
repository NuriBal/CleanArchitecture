using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Command.CreateUserRole;

public sealed record CreateUserRoleCommand(string RoleId, string UserId) : IRequest<MessageResponse>;

