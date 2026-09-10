using CleanArchitecture.Application.Services;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login
{
    public sealed class LoginCommandHadler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public LoginCommandHadler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            LoginCommandResponse response = await _authService.LoginAsync(request, cancellationToken);

            return response;
        }
    }
}
