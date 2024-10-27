#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Bills.GetBillsInGroup;

public sealed record GetBillsInGroupQuery(Guid GroupId, int PageIndex, int PageSize) : IQuery<IEnumerable<BillDto>>;