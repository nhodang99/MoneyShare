#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Auth.Login;

public sealed record LoginUserCommand(string Email, string Password) : ICommand<LoginUserResponse>;