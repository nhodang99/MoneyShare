using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Users.Register;

public sealed record RegisterUserCommand(string Email, string UserName, string Password)
    : ICommand<Guid>;
