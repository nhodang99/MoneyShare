using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Groups.InviteUsers;

public sealed record InviteUsersToGroupCommand(Guid GroupId, Guid[] UserIds) : ICommand;