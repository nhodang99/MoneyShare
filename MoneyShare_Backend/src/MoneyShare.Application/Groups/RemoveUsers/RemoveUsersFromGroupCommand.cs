using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Groups.RemoveUsers;

public sealed record RemoveUsersFromGroupCommand(Guid GroupId, Guid[] UserIds) : ICommand;