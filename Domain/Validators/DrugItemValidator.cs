using Domain.Entities;
using FluentValidation;

namespace DrugsBot.Validators;

public class DrugItemValidator : AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        RuleFor(d => d.Drug)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
        RuleFor(d => d.DrugId)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull);
        RuleFor(d => d.DrugStore)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
        RuleFor(d => d.DrugStoreId)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .NotNull().WithMessage(ValidationMessage.NotNull);
        RuleFor(d => d.Cost)
            .GreaterThan(0).WithMessage(ValidationMessage.PositiveNumber);
        RuleFor(d => d.Count)
            .GreaterThan(0).WithMessage(ValidationMessage.PositiveNumber);
    }
}