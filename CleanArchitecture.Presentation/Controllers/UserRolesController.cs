using CleanArchitecture.Application.Features.UserRoleFeatures.Command.CreateUserRole;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Infrastructure.Authorization;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

public sealed class UserRolesController : ApiController
{
    public UserRolesController(IMediator mediator) : base(mediator) { }

    [RoleFilter("Create")]
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}