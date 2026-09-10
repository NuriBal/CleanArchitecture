using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(p => p.EMail).NotEmpty().WithMessage("Mail bilgisi boş olamaz!");
        RuleFor(p => p.EMail).NotNull().WithMessage("Mail bilgisi boş olamaz!");
        RuleFor(p => p.EMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz!");

        RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı adı bilgisi boş olamaz!");
        RuleFor(p => p.UserName).NotNull().WithMessage("Kullanıcı adı bilgisi boş olamaz!");
        RuleFor(p => p.UserName).MinimumLength(6).WithMessage("Kullanıcı adı en az 6 karakter olmalıdır!");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Parola bilgisi boş olamaz!");
        RuleFor(p => p.Password).NotNull().WithMessage("Parola bilgisi boş olamaz!");
        RuleFor(p => p.Password).MinimumLength(6).WithMessage("Parola en az 6 karakter olmalıdır!");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Parola bilgisinde en az 1 adet büyük harf içermelidir!");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Parola bilgisinde en az 1 adet küçük harf içermelidir!");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Parola bilgisinde en az 1 adet rakam içermelidir!");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Parola bilgisinde en az 1 adet özel karakter içermelidir!");

        RuleFor(p => p.FirstName).NotEmpty().WithMessage("İsim bilgisi boş olamaz!");
        RuleFor(p => p.FirstName).NotNull().WithMessage("İsim bilgisi boş olamaz!");
        RuleFor(p => p.FirstName).MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır!");

        RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyisim bilgisi boş olamaz!");
        RuleFor(p => p.LastName).NotNull().WithMessage("Soyisim bilgisi boş olamaz!");
        RuleFor(p => p.LastName).MinimumLength(2).WithMessage("Soyisim en az 2 karakter olmalıdır!");
    }
}
