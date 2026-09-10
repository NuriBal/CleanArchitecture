using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı yada mail bilgisi boş olamaz!");
        RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Kullanıcı adı yada mail bilgisi boş olamaz!");
        RuleFor(p => p.UserNameOrEmail).MinimumLength(6).WithMessage("Kullanıcı adı yada mail en az 6 karakter olmalıdır!");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Parola bilgisi boş olamaz!");
        RuleFor(p => p.Password).NotNull().WithMessage("Parola bilgisi boş olamaz!");
        RuleFor(p => p.Password).MinimumLength(6).WithMessage("Parola en az 6 karakter olmalıdır!");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Parola bilgisinde en az 1 adet büyük harf içermelidir!");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Parola bilgisinde en az 1 adet küçük harf içermelidir!");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Parola bilgisinde en az 1 adet rakam içermelidir!");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Parola bilgisinde en az 1 adet özel karakter içermelidir!");
    }
}
