using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Groups.Delete;

public sealed record DeleteGroupCommand(Guid GroupId) : ICommand;
