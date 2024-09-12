using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Bills.GetById;

public sealed record GetBillByIdQuery(Guid BillId) : IQuery<BillDTO>;
