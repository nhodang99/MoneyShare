#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Groups.RemoveUsers;

public sealed record RemoveUsersFromGroupCommand(Guid GroupId, Guid[] UserIds) : ICommand;