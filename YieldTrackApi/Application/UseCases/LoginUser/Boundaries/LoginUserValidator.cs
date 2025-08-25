using FluentValidation;

namespace Application.UseCases.LoginUser.Boundaries;

public sealed class LoginUserValidator : AbstractValidator<LoginUserInput>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("The email is required.")
            .EmailAddress().WithMessage("The email format is invalid.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("The password is required.");
    }
}
