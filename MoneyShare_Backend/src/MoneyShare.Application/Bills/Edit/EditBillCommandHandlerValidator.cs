using FluentValidation;

namespace MoneyShare.Application.Bills.Edit;

internal sealed class EditBillCommandHandlerValidator : AbstractValidator<EditBillCommand>
{
    public EditBillCommandHandlerValidator()
    {
        RuleFor(b => b.Title).NotEmpty();
        RuleFor(b => b.Price).GreaterThan(0);
    }
}
