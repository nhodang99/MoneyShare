#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Bills.GetById;

public sealed record GetBillByIdQuery(Guid BillId) : IQuery<BillDto>;