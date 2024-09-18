using MoneyShare.Application.Contracts.Messaging;

namespace MoneyShare.Application.Bills.Delete;

public sealed record DeleteBillCommand(Guid BillId) : ICommand;
