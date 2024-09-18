using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Bills.GetBillsInGroup;

public sealed record GetBillsInGroupQuery(Guid GroupId, int PageIndex, int PageSize) : IQuery<IEnumerable<BillDTO>>;
