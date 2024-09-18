using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Groups.GetById;

public sealed record GetGroupByIdQuery(Guid Id) : IQuery<GroupDTO>;
