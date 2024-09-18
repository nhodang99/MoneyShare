using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

namespace MoneyShare.Application.Bills.Delete;

internal sealed class DeleteBillCommandHandler(IBillService billService) : ICommandHandler<DeleteBillCommand>
{
    public async Task<Result> Handle(DeleteBillCommand command, CancellationToken cancellationToken)
    {
        return await billService.DeleteBill(command.BillId, cancellationToken);
    }
}
