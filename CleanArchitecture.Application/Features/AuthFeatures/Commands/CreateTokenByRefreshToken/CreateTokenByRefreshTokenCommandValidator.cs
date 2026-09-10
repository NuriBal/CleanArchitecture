using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateTokenByRefreshToken;

public sealed class CreateTokenByRefreshTokenCommandValidator : AbstractValidator<CreateTokenByRefreshTokenCommand>
{
    public CreateTokenByRefreshTokenCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("Kullanıcı bilgisi boş olamaz!");
        RuleFor(p => p.UserId).NotNull().WithMessage("Kullanıcı bilgisi boş olamaz!");
        RuleFor(p => p.RefreshToken).NotEmpty().WithMessage("Refresh token bilgisi boş olamaz!");
        RuleFor(p => p.RefreshToken).NotNull().WithMessage("Refresh token bilgisi boş olamaz!");
    }
}
