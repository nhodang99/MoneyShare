using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Groups.GetAll;

public sealed record GetAllGroupsQuery() : IQuery<IEnumerable<GroupDTO>>;
