#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Users.GetAll;

public sealed record GetAllUsersQuery : IQuery<List<UserDto>>;