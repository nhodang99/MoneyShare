using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Users.Delete;

public sealed record DeleteUserCommand(Guid UserId) : ICommand;
