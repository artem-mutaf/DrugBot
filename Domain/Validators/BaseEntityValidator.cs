namespace DrugsBot.Validators;
using Domain.Entities;
using FluentValidation;

public class BaseEntityValidator: AbstractValidator<BaseEntity>
{
    public BaseEntityValidator()
    {
        RuleFor(d => d.Id)
            .NotEqual(Guid.Empty).WithMessage(ValidationMessage.NotEmpty);
    }
}