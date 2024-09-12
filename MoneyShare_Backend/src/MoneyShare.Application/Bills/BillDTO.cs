using MoneyShare.Domain.Bills;

namespace MoneyShare.Application.Bills;

public sealed record BillDTO(Guid Id, string Title, string Price, BillStatus Status, Guid GroupId, Guid PayerId);
