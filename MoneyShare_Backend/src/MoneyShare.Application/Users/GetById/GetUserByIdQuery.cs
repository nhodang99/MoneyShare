#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Users.GetById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserDto>;