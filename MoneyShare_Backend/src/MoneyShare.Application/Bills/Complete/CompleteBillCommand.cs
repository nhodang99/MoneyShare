using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Bills.Complete;

public sealed record CompleteBillCommand(Guid Id) : ICommand;
