#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Groups.InviteUsers;

public sealed record InviteUsersToGroupCommand(Guid GroupId, Guid[] UserIds) : ICommand;