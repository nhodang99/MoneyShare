using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

namespace MoneyShare.Application.Bills.Complete;

internal sealed class CompleteBillCommandHandler(IBillService billService) : ICommandHandler<CompleteBillCommand>
{
    public async Task<Result> Handle(CompleteBillCommand command, CancellationToken cancellationToken)
    {
        return await billService.CompleteBill(command.Id, cancellationToken);
    }
}
