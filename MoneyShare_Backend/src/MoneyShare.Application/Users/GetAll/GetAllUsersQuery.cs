using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Users.GetAll;

public sealed record GetAllUsersQuery() : IQuery<List<UserDTO>>;
