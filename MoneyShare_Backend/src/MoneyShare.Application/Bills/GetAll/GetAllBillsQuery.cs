#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Bills.GetAll;

public sealed record GetAllBillsQuery : IQuery<IEnumerable<BillDto>>;