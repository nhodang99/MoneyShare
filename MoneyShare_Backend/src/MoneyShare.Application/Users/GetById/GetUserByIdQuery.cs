using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Users.GetById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserDTO>;
