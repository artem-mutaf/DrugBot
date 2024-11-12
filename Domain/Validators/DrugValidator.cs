namespace DrugsBot.Validators;
using Domain.Entities;
using FluentValidation;

public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        //ДЗ скинут правила и описать валидации для каждого класса 
        
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 28).WithMessage(ValidationMessage.WrongLength);
        RuleFor(d => d.CountryCodeId)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Matches(@"^\\d{2}$").WithMessage(ValidationMessage.InvalidCharacters);
        RuleFor(d => d.Manufacturer)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 50).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[a-zA-Z\s]+$").WithMessage(ValidationMessage.InvalidCharacters);
        RuleFor(d => d.Country.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 50).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[a-zA-Z\s]+$").WithMessage(ValidationMessage.InvalidCharacters);
        //Написать тесты для проверки валидаций проходиться по объектсам и проверять валидации тесты на XUnity

    }
}