using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Users.Edit;

public sealed record EditUserCommand(Guid Id, string UserName, string Email, string Password) : ICommand;
