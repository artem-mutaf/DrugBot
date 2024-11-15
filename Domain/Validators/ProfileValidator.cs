using Domain.Entities;
using FluentValidation;

namespace DrugsBot.Validators;

public class ProfileValidator: AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        RuleFor(profile => profile.Email)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Не правильный формат Email")
            .MaximumLength(255).WithMessage("Email может содержать максимум 255 символов");
    }
}