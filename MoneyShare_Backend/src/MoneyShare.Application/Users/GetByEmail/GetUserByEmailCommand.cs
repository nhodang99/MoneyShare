#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Users.GetByEmail;

public sealed record GetUserByEmailCommand(string Email) : ICommand<UserDto>;