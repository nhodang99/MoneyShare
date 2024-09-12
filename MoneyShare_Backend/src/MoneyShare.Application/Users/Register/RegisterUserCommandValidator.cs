using FluentValidation;

namespace MoneyShare.Application.Users.Register;

internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.UserName)
            .NotEmpty()
            .MaximumLength(50)
            .MinimumLength(3);

        RuleFor(c => c.Email).NotEmpty().EmailAddress();

        RuleFor(c => c.Password).NotEmpty().MinimumLength(8);
    }
}
