namespace MoneyShare.Application.Contracts.Requests;

public sealed record AddUsersToGroupReq(Guid GroupId, Guid[] UserIds);

public sealed record RemoveUsersFromGroupReq(Guid GroupId, Guid[] UserIds);
