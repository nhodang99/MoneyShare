#region

using MoneyShare.Application.Interfaces.Messaging;

#endregion

namespace MoneyShare.Application.Bills.Delete;

public sealed record DeleteBillCommand(Guid BillId) : ICommand;