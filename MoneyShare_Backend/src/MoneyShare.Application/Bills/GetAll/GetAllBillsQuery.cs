using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Bills.GetAll;

public sealed record GetAllBillsQuery() : IQuery<IEnumerable<BillDTO>>;
