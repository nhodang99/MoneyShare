using MoneyShare.Domain.Bills;

namespace MoneyShare.Application.Contracts.DTOs;

public record BillDTO(Guid Id, string Title, string Price, BillStatus Status, Guid GroupId, Guid PayerId);
