using FluentValidation;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;

public sealed class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı zorunludur.").NotNull().WithMessage("Ad alanı zorunludur.").MaximumLength(10).WithMessage("Ad alanı en az 10 karakter olmalıdır.");
        RuleFor(x => x.Model).NotEmpty().WithMessage("Model alanı zorunludur.").NotNull().WithMessage("Model alanı zorunludur.").MaximumLength(10).WithMessage("Model alanı en az 10 karakter olmalıdır.");
        RuleFor(x => x.EnginePower).NotEmpty().WithMessage("Motor gücü alanı zorunludur.").NotNull().WithMessage("Motor gücü alanı zorunludur.").GreaterThan(0).WithMessage("Motor gücü alanı 0'dan büyük olmalıdır.");
    }
}
