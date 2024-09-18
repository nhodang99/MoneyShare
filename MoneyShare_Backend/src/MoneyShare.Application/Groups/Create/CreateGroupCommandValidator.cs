using FluentValidation;

namespace MoneyShare.Application.Groups.Create;

internal sealed class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
    public CreateGroupCommandValidator()
    {
        RuleFor(g => g.Name).NotEmpty().MaximumLength(50);
    }
}
