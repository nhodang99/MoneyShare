using FluentValidation;

namespace MoneyShare.Application.Groups.Edit;

internal sealed class EditGroupCommandValidator : AbstractValidator<EditGroupCommand>
{
    public EditGroupCommandValidator()
    {
        RuleFor(g => g.Id).NotEmpty();
        RuleFor(g => g.Name).NotEmpty().MaximumLength(50);
    }
}
