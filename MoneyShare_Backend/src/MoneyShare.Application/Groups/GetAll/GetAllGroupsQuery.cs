#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Groups.GetAll;

public sealed record GetAllGroupsQuery : IQuery<IEnumerable<GroupDto>>;