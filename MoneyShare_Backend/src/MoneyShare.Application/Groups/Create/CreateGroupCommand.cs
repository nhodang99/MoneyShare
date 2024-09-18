using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Groups.Create;

public sealed record CreateGroupCommand(string Name) : ICommand<Guid>;
