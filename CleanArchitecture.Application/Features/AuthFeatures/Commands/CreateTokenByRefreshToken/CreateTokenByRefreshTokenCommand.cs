using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateTokenByRefreshToken;

public sealed record CreateTokenByRefreshTokenCommand(
    string UserId,
    string RefreshToken) : IRequest<LoginCommandResponse>;
