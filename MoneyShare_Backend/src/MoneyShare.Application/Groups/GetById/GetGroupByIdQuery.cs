#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Groups.GetById;

public sealed record GetGroupByIdQuery(Guid Id) : IQuery<GroupDto>;