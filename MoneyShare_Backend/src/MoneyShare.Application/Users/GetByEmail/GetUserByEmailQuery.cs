using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Users.GetByEmail;

public sealed record GetUserByEmailQuery(string Email) : IQuery<UserDTO>;
