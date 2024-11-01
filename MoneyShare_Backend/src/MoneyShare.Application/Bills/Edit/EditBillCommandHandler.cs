﻿#region

using AutoMapper;
using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Bills.Edit;

internal sealed class EditBillCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IBillDomainService billService)
    : ICommandHandler<EditBillCommand>
{
    public async Task<Result> Handle(EditBillCommand command, CancellationToken cancellationToken)
    {
        Bill? bill = await unitOfWork.Bills.SingleOrDefaultAsync(b => b.Id == command.Id, cancellationToken);
        if (bill is null)
        {
            return Result.Failure(BillErrors.NotFound(command.Id));
        }

        bill = mapper.Map<Bill>(command);

        return await billService.EditBillAsync(bill, cancellationToken);
    }
}