#region

using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Bills.Complete;

internal sealed class CompleteBillCommandHandler(IBillDomainService billService) : ICommandHandler<CompleteBillCommand>
{
    public async Task<Result> Handle(CompleteBillCommand command, CancellationToken cancellationToken)
    {
        return await billService.CompleteBillAsync(command.Id, cancellationToken);
    }
}