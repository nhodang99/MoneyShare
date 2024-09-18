using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyShare.Application.Bills.Create;

internal sealed class CreateBillCommandHandlerValidator : AbstractValidator<CreateBillCommand>
{
    public CreateBillCommandHandlerValidator()
    {
        RuleFor(b => b.Title).NotEmpty();
        RuleFor(b => b.Price).GreaterThan(0);
    }
}
