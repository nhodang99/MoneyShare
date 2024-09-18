using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Groups.Edit;

public sealed record EditGroupCommand(Guid Id, string Name) : ICommand;
