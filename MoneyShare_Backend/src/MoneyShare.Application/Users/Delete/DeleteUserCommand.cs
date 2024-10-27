#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Users.Delete;

public sealed record DeleteUserCommand(Guid UserId) : ICommand;