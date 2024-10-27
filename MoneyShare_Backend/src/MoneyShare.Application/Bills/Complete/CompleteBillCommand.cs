#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Bills.Complete;

public sealed record CompleteBillCommand(Guid Id) : ICommand;