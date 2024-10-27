using FluentValidation;

namespace MoneyShare.Application.Auth.Register;
internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(u => u.UserName)
            .NotEmpty()
            .MaximumLength(50)
            .MinimumLength(3);

        RuleFor(u => u.Email).NotEmpty().EmailAddress();

        RuleFor(u => u.Password).NotEmpty().MinimumLength(8);

        RuleFor(u => u.ConfirmPassword).NotEmpty().MinimumLength(8);
    }
}
