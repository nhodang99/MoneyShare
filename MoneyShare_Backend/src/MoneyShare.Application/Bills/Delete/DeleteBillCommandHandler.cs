#region

using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Bills.Delete;

internal sealed class DeleteBillCommandHandler(IBillDomainService billService) : ICommandHandler<DeleteBillCommand>
{
    public async Task<Result> Handle(DeleteBillCommand command, CancellationToken cancellationToken)
    {
        return await billService.DeleteBillAsync(command.BillId, cancellationToken);
    }
}