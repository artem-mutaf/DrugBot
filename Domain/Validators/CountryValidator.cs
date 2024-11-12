namespace DrugsBot.Validators;
using Domain.Entities;
using FluentValidation;

public class CountryValidator: AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(d => d.Name)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(ValidationMessage.InvalidCharacters);
        RuleFor(d => d.Code)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .Matches(@"^\d+$").WithMessage(ValidationMessage.InvalidCharacters)
            .Must(value => decimal.TryParse(value, out var result) && result > 0)
            .WithMessage(ValidationMessage.PositiveNumber);
    }
}