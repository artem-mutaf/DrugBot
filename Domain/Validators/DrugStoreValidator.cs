using System.ComponentModel;
using System.Data;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Validators;

namespace DrugsBot.Validators;

public class DrugStoreValidator: AbstractValidator<DrugStore>
{
    public DrugStoreValidator()
    {
        RuleFor(d => d.DrugNetwork)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
        RuleFor(d => d.Number)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .GreaterThan(0).WithMessage(ValidationMessage.PositiveNumber);
        RuleFor(d => d.Address.City)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 50).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(ValidationMessage.InvalidCharacters);
        RuleFor(d => d.Address.Street)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(3, 100).WithMessage(ValidationMessage.WrongLength)
            .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(ValidationMessage.InvalidCharacters);
        RuleFor(d => d.Address.House)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Matches(@"^[a-zA-Zа-яА-Я0-9]+$").WithMessage(ValidationMessage.InvalidCharacters);
            
    }
    
}