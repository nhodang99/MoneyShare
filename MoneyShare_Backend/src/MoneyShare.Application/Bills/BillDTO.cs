using MoneyShare.Domain.Bills;

namespace MoneyShare.Application.Bills;

public sealed record BillDto(Guid Id, string Title, decimal Price, BillStatus Status, Guid GroupId, Guid PayerId);
