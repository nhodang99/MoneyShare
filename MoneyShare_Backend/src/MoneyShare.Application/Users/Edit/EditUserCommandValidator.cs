using FluentValidation;

namespace MoneyShare.Application.Users.Edit;

internal sealed class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(u => u.Id).NotEmpty();
        RuleFor(u => u.UserName)
            .NotEmpty()
            .MaximumLength(50)
            .MinimumLength(3);

        RuleFor(u => u.Email).NotEmpty().EmailAddress();

        RuleFor(u => u.Password).NotEmpty().MinimumLength(8);
    }
}
