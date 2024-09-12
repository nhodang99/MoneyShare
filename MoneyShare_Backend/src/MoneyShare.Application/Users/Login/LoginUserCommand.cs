using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Users.Login;

public sealed record LoginUserCommand(string Email, string Password) : ICommand<string>;
